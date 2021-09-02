Imports System

Module Program
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
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine(ValidationResults)
                    Console.ResetColor()
                Else
                    Dim ModifiedData As String = ModifyData(NewData)
                    StoreData(ModifiedData, DataBase)
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
                                "2. Dsiplay all data",
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

    Public Function ModifyData(NewData As String)
        Dim SubDatas As New Dictionary(Of Integer, Integer)()
        Dim SplitedData As String() = NewData.Split(New Char() {","c})

        Dim i As Integer = 0
        For Each sd As String In SplitedData
            SubDatas(i) = Integer.Parse(sd)
            i += 1
        Next

        For s As Integer = 1 To 3
            If SubDatas(s) < 20 Then
                SubDatas(s) = 20
            End If
        Next

        Dim ModifiedData As String = SubDatas(0).ToString()

        For s As Integer = 1 To 3
            ModifiedData += "," + SubDatas(s).ToString()
        Next


        'Console.ForegroundColor = ConsoleColor.Blue
        'Console.WriteLine("Some results were under 20 and has been converted to 20.")'
        'Console.ResetColor() '

        Return ModifiedData

    End Function

    Public DataBase As New Dictionary(Of String, String)

    Public Sub StoreData(ModifiedData As String, ByRef DataBase As Dictionary(Of String, String))
        Dim SubDatas As New Dictionary(Of String, String)()
        Dim SplitedData As String() = ModifiedData.Split(New Char() {","c})

        Dim i As Integer = 0
        For Each sd As String In SplitedData
            SubDatas(i) = sd
            i += 1
        Next

        DataBase(SubDatas(0)) = ModifiedData

        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("Data is valid and stored")
        Console.ResetColor()
    End Sub

    Public Function CalculateDataAverage()
        ' "MAX1, MIN1, AVG1, MAX2, MAX3"
    End Function

    Public Function ParseOneRecord(record As String)
        Return record.Split(",")
    End Function

    Public Sub DisplayData()
        PrintOneLine("ID", "English", "Maths", "Science")
        Console.WriteLine(("").PadRight(52, "-"))
        For Each record As KeyValuePair(Of String, String) In DataBase
            PrintOneLine(record.Key, record.Value.Split(",")(1),
                         record.Value.Split(",")(2),
                         record.Value.Split(",")(3))

        Next

    End Sub

    Public Sub PrintOneLine(col1 As String,
                            col2 As String,
                            col3 As String,
                            col4 As String)
        Console.WriteLine(col1.PadRight(13, " ") +
                          col2.PadRight(13, " ") +
                          col3.PadRight(13, " ") +
                          col4.PadRight(13, " ")
                          )

    End Sub

    Private Sub SearchData()
        Console.WriteLine("Enter student ID number to get specific results: ")
        Console.WriteLine("Displayed in format of (ID, Result_English, Result_Maths, Result_Science)")
        Dim SearchedID As String = Console.ReadLine()
        Try
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("Student " + SearchedID + "'s result details : " + DataBase(SearchedID))
            Console.ResetColor()
        Catch
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Student '" + SearchedID + "' Not Found")
            Console.ResetColor()
        End Try
    End Sub

    'A linebreak function existing purely for visuals.
    Public Sub LineBreak()
        Console.WriteLine("")
    End Sub
End Module