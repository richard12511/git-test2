
let main argv = 
    printfn "Hello World" 

let add x y =
    x + y


let isLessThan100 number = 
    if number < 100 then
        printfn "Less than 100"
    else
        printfn "Not less than 100"

let answer = add 42 43 |> isLessThan100

let double x =
    x * 2

let addTwoAndDouble x =
    double(add x 2)
