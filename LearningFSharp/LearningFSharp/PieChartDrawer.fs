namespace LearningFSharp
open System
open System.Drawing
open System.IO

type PieChartDrawer() =

    member x.ConvertDataRow (csvLine: string) =
        let cells = List.ofSeq(csvLine.Split(','))
        match cells with
        | title::number::_ ->
            let parsedNumber = Int32.Parse(number)
            (title, parsedNumber)
        | _ -> failwith "Incorrect data format"  
        
    member x.ProcessLines lines =
        match lines with
        | [] -> []
        | currentLine::remainingLines ->
            let parsedCurrentLine = x.ConvertDataRow(currentLine)
            let parsedRemainingLines = x.ProcessLines(remainingLines)
            parsedCurrentLine::parsedRemainingLines  

    member x.CalculateSum rows =
        match rows with
        | [] -> 0
        | (_, value)::tail -> 
            let remainingSum = x.CalculateSum(tail)
            value + remainingSum

    member x.CalculateAngle part whole =
        int(float(part) / float(whole) * 360.0)

    member x.Random = new Random()
    member x.RandomBrush () =
        let r, g, b = x.Random.Next(256), x.Random.Next(256), x.Random.Next(256)
        new SolidBrush(Color.FromArgb(r, g, b))

    member x.DrawPieSegment (graphics:Graphics, title, startAngle, occupiedAngle) =
        let brush = x.RandomBrush ()
        graphics.FillPie(brush, 170, 70, 260, 260, startAngle, occupiedAngle)
        brush.Dispose()

    member x.DrawLabel (graphics:Graphics, title, startAngle, angle) = 
        let font = new Font("Times New Roman", 11.0f)
        let centerX = 300.0
        let centerY = 200.0
        let labelDistance = 150.0

        let labelAngle = float(startAngle + angle/2)
        let ra = Math.PI * 2.0 * labelAngle / 360.0
        let x = centerX + labelDistance * cos(ra)
        let y = centerY + labelDistance * sin(ra)
        let size = graphics.MeasureString(title, font)
        let rc = new PointF(float32(x) - size.Width/2.0f, float32(y) - size.Height/2.0f) 
        graphics.DrawString(title, font, Brushes.Black, new RectangleF(rc, size))

    member x.DrawStep (drawingFunction, graphics : Graphics, sum, tuples) =
        let rec drawStepUtil (tuples, angleSoFar) =
            match tuples with
            | [] -> ()
            | [title, value] ->
                let angle = 360 - angleSoFar
                drawingFunction(graphics, title, angleSoFar, angle)
            | (title, value)::tail ->
                let angle = x.CalculateAngle value sum
                drawingFunction(graphics, title, angleSoFar, angle)
                drawStepUtil(tail, angleSoFar)
        drawStepUtil(tuples, 0)

    member x.DrawChart (file) =
        let lines = List.ofSeq(File.ReadAllLines(file))
        let data = x.ProcessLines(lines)
        let sum = x.CalculateSum(data)

        let pieChart = new Bitmap(600, 400)
        let graphics = Graphics.FromImage(pieChart)
        graphics.Clear(Color.White)
        x.DrawStep(x.DrawPieSegment, graphics, sum, data)
        x.DrawStep(x.DrawLabel, graphics, sum, data)

        graphics.Dispose()
        pieChart
        
    

