Sub Wall_Street()

    Dim ws_count As Integer
    Dim I As Integer
    
    'Set ws_count equal to the number of worksheets in the active workbook.
    ws_count = ActiveWorkbook.Worksheets.Count
    
    'Begin the loop.
    For I = 1 To ws_count
    

Dim last_row As Long
Dim ticker As String
Dim change As Double
Dim percent As Double
Dim total As Double
Dim openprice As Double
Dim closeprice As Double
Dim diff As Double
Dim summary_row As Long

last_row = Cells(Rows.Count, 1).End(xlUp).Row
total = 0
change = 0
percent = 0
diff = 0
summary_row = 1

'create headers
Cells(1, 9).Value = "Ticker"
Cells(1, 10).Value = "Yearly Change"
Cells(1, 11).Value = "Percentage Change"
Cells(1, 12).Value = " Total Stock Volume "
'-----------------------------------------

'loop through to get total volume

openprice = Cells(2, 3).Value
For last_row = 2 To last_row
total = total + Cells(last_row, 7).Value

'move to next ticker
If Cells(last_row, 1) <> Cells(last_row + 1, 1) Then
summary_row = summary_row + 1
ticker = Cells(last_row, 1)

'show change in close price
closeprice = Cells(last_row, 6).Value
change = (closeprice - openprice)

'make negative changes red and positive changes green
If change < 0 Then
Cells(summary_row, 10).Interior.ColorIndex = 3
Else
Cells(summary_row, 10).Interior.ColorIndex = 4
End If

'fix undefined percentages
If openprice = 0 Then
percentage = 0
Else
percentage = change / openprice
End If

'format summary row cells
Cells(summary_row, 9) = ticker
Cells(summary_row, 10).Value = change
Cells(summary_row, 10).NumberFormat = "0.000000000"
Cells(summary_row, 11).Value = percentage
Cells(summary_row, 11).NumberFormat = "0.00%"
Cells(summary_row, 12).Value = total
total = 0
change = 0
openprice = 0
closeprice = 0
openprice = Cells(last_row + 1, 3)

End If

Next last_row

MsgBox ("Ding! Results are Ready!")

Next I

End Sub


