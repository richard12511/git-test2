namespace LearningFSharp

open System
open System.IO
open System.Drawing
open System.Windows.Forms

module Startup =    

    let mainForm = new Form(Width = 620, Height = 450, Text = "Pie Chart")
    
    let menu = new ToolStrip();
    let buttonOpen = new ToolStripButton("Open")
    let buttonSave = new ToolStripButton("Save", Enabled = false)
    menu.Items.Add(buttonOpen) |> ignore
    menu.Items.Add(buttonSave) |> ignore
    
    let boxChart = new PictureBox(BackColor = Color.White, Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.CenterImage)
    
    mainForm.Controls.Add(menu)
    mainForm.Controls.Add(boxChart);

    let openAndDrawChart (e) =
        let dialog = new OpenFileDialog(Filter = "CSV Files|*.csv")
        if(dialog.ShowDialog() = DialogResult.OK) then
            let pieChartDrawer = new PieChartDrawer()
            let pieChart = pieChartDrawer.DrawChart(dialog.FileName)
            boxChart.Image <- pieChart
            buttonSave.Enabled <- true

    let saveDrawing (e) =
        let dialog = new SaveFileDialog(Filter="PNG files|*.png")
        if(dialog.ShowDialog() = DialogResult.OK) then
            boxChart.Image.Save(dialog.FileName)

    [<STAThread>]
    do
        buttonOpen.Click.Add(openAndDrawChart)
        buttonSave.Click.Add(saveDrawing)
        Application.Run(mainForm) 