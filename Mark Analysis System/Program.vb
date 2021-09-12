Imports System

Module Program
    Public Class StudentRecord
        Public Property ID As Integer
        Public Property Math As Integer
        Public Property English As Integer
        Public Property Science As Integer

        Private Property IsScoreModified As Boolean = False

        Public Overrides Function ToString() As String
            Return String.Format("[{0}, {1}, {2}, {3}]", Me.ID, Me.English, Me.Math, Me.Science)
        End Function

        Public Shared Function ParseRecordFromString(InputString As String) As StudentRecord
            Dim newStudentRecord = New StudentRecord()
            newStudentRecord.ID = Integer.Parse(InputString.Split(",")(0))
            newStudentRecord.English = Integer.Parse(InputString.Split(",")(1))
            newStudentRecord.Math = Integer.Parse(InputString.Split(",")(2))
            newStudentRecord.Science = Integer.Parse(InputString.Split(",")(3))

            Return newStudentRecord
        End Function

        Public Function ModifyData()
            Me.English = Me.ModifyOneSubject(Me.English)
            Me.Math = Me.ModifyOneSubject(Me.Math)
            Me.Science = Me.ModifyOneSubject(Me.Science)

            If Me.IsScoreModified Then
                PromptWithColor(ConsoleColor.Blue, "Some results were under 20 and has been converted to 20.")
            End If

            Return Me
        End Function

        Private Function ModifyOneSubject(score As Integer)
            If score < 20 Then
                Me.IsScoreModified = True
                Return 20
            End If

            Return score
        End Function
    End Class

    Sub Main()
        Dim ProgramStatus As String = "running" 'condition for program to keep running
        While ProgramStatus = "running"

            'Brings up the selections menu
            LineBreak()
            Dim UserSelection As String = MenuPrompt()
            LineBreak()

            If UserSelection = "1" Then
                Dim NewData As String = InputDataPrompt()
                Dim ValidationResults As String = ValidateData(NewData)
                If ValidationResults <> "valid" Then 'print error
                    PromptWithColor(ConsoleColor.Red, ValidationResults)
                Else
                    StudentRecords.Add(StudentRecord.ParseRecordFromString(NewData).ModifyData())
                End If
            ElseIf UserSelection = "2" Then
                Console.ForegroundColor = ConsoleColor.Yellow
                DisplayData()
                Console.ResetColor()
            ElseIf UserSelection = "3" Then
                SearchData()
            ElseIf UserSelection = "-1" Then 'exit program
                Console.WriteLine("Exiting Program...")
                ProgramStatus = "stopped"
            Else 'invalid input Then print error and loops back
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Please enter a valid option, (numbers 1~3 or -1 to exit)")
                Console.ResetColor()
            End If

        End While
    End Sub

    Public Function MenuPrompt()
        Dim options As Array = {"1. Input data for a student",
                                "2. Display all data",
                                "3. Search for a student's results by ID number", "-1. Exit"
                                }

        Dim i As Integer = 0
        Dim OptionNumbers As Integer = options.Length
        Do While i < OptionNumbers
            Console.WriteLine(options(i))
            i += 1
        Loop
        LineBreak()

        Console.WriteLine("Enter option number to select option(eg. 1 for option 1. or -1 to exit): ")
        Return Console.ReadLine()
    End Function

    Public Function InputDataPrompt()
        Console.WriteLine("Input data for a student in the following format :")
        Console.WriteLine("    ID, Result_English, Result_Maths, Result_Science")
        Console.WriteLine("    (e.g. 20300,80,90,100) :")
        Return Console.ReadLine()
    End Function

    Public Function ValidateData(data As String)
        Dim SubData As New Dictionary(Of Integer, Integer)()
        Dim SplitedData As String() = data.Split(New Char() {","c})

        'checks if input is four data seperated by three commas
        Dim Counter As Integer = 0
        For Each c As Char In data
            If c = "," Then
                Counter += 1
            End If
        Next
        If Counter <> 3 Then
            Return "Invalid input: Wrong data format"
        End If

        'Checks that each subdata inputed is Integer with Try(Integer.Parse)
        Dim i As Integer = 0
        For Each sd As String In SplitedData
            Try
                SubData(i) = Integer.Parse(sd)
            Catch
                Return "Invalid input: subdata should be integers"
            End Try
            i += 1
        Next

        'Checks if student ID number is 5 digit long
        Const STUDENT_ID_LENGTH As Integer = 5
        If SubData(0).ToString.Length <> STUDENT_ID_LENGTH Then 'Invalid ID input
            Return "Invalid student ID number, ID number should be a 5 digit Integer"
        End If

        'Checks that the results inputed are integers between 0 and 100
        Const RESULT_MAX As Integer = 100
        Const RESULT_MIN As Integer = 0
        For s As Integer = 1 To 3
            If SubData(s) > RESULT_MAX Or SubData(s) < RESULT_MIN Then
                Return "Invalid Result: result must be an Integer between 100 and 0"
            End If
        Next

        Return "valid"
    End Function

    Public StudentRecords As New List(Of StudentRecord)

    Public Sub PromptWithColor(Color As ConsoleColor, Prompt As String)
        Console.ForegroundColor = Color
        Console.WriteLine(Prompt)
        Console.ResetColor()
    End Sub

    Public Sub DisplayData()
        PrintOneLine("ID", "English", "Maths", "Science")
        RuleOff(52, "-")

        If StudentRecords.Count > 0 Then
            For Each record As StudentRecord In StudentRecords
                PrintOneLine(record.ID.ToString(),
                         record.English.ToString(),
                         record.Math.ToString(),
                         record.Science.ToString())
            Next

            Dim AvgEnglish As Integer = StudentRecords.Average(Function(r) r.English)
            Dim MaxEnglish As Integer = StudentRecords.Max(Function(r) r.English)
            Dim MinEnglish As Integer = StudentRecords.Min(Function(r) r.English)

            Dim AvgMath As Integer = StudentRecords.Average(Function(r) r.Math)
            Dim MaxMath As Integer = StudentRecords.Max(Function(r) r.Math)
            Dim MinMath As Integer = StudentRecords.Min(Function(r) r.Math)

            Dim AvgScience As Integer = StudentRecords.Average(Function(r) r.Science)
            Dim MaxScience As Integer = StudentRecords.Max(Function(r) r.Science)
            Dim MinScience As Integer = StudentRecords.Min(Function(r) r.Science)

            PrintOneLine("AVERAGE",
             AvgEnglish.ToString(),
             AvgMath.ToString(),
             AvgScience.ToString())

            PrintOneLine("MAX",
             MaxEnglish.ToString(),
             MaxMath.ToString(),
             MaxScience.ToString())

            PrintOneLine("MIN",
             MinEnglish.ToString(),
             MinMath.ToString(),
             MinScience.ToString())
        Else
            PromptWithColor(ConsoleColor.Yellow, "No data has been stored yet")
        End If
    End Sub

    Private Sub RuleOff(Length As Integer, Symbol As String)
        Console.WriteLine(("").PadRight(Length, Symbol))
    End Sub

    Public Sub PrintOneLine(col1 As String,
                            col2 As String,
                            col3 As String,
                            col4 As String)

        Console.WriteLine(col1.PadRight(13, " ") +
                          col2.PadRight(13, " ") +
                          col3.PadRight(13, " ") +
                          col4.PadRight(13, " "))
    End Sub

    Private Sub SearchData()
        Console.WriteLine("Enter student ID number to get specific results: ")
        Console.WriteLine("Displayed in format of (ID, Result_English, Result_Maths, Result_Science)")
        Dim SearchedID As String = Console.ReadLine()
        Dim RecordFound As StudentRecord = StudentRecords.Find(Function(r) r.ID = SearchedID)

        If IsNothing(RecordFound) = False Then
            PromptWithColor(ConsoleColor.Yellow, "Student " + SearchedID + "'s result details : " + RecordFound.ToString)
        Else
            PromptWithColor(ConsoleColor.Red, "Student '" + SearchedID + "' Not Found")
        End If
    End Sub

    'A linebreak function existing purely for visuals.
    Public Sub LineBreak()
        Console.WriteLine("")
    End Sub
End Module