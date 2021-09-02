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
                    StoreData(ModifiedData)
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine("data is valid and stored")
                    Console.ResetColor()
                End If
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
        Dim options As Array = {"1. Input data for a student", "2. Unavailable", "3. Unavailable", "-1. Exit"}

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
        Console.WriteLine("Input data for a student in the following format:")
        Console.WriteLine("    ID, Result_English, Result_Maths, Result_Science")
        Console.WriteLine("    (e.g. 20300,80,90,100)")
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

        Console.ForegroundColor = ConsoleColor.Blue
        Console.WriteLine("Some results were under 20 and has been converted to 20.")
        Console.ResetColor()

        Return ModifiedData

    End Function

    Public Sub StoreData(ModifiedData As String)
        Console.WriteLine(ModifiedData)
    End Sub

    Public Function CalculateDataAverage()

    End Function

    Public Sub DisplayData()

    End Sub

    'A linebreak function existing purely for visuals.
    Public Sub LineBreak()
        Console.WriteLine("")
    End Sub

    Public O As New Object
End Module