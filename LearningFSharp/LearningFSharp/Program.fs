open System.Windows.Forms
open System.Drawing

type HelloWindow() =
    let form = new Form(Width = 400, Height = 140)
    let font = new Font("Times New Roman", 28.0f)
    let label = new Label(Dock = DockStyle.Fill, Font = font, TextAlign = ContentAlignment.MiddleCenter)
    do form.Controls.Add(label)

    member x.SayHello name =
        let message = "Hello " + name + "!"
        label.Text <- message

    member x.Run =
        Application.Run form