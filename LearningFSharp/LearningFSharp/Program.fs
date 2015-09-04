
let main argv = 
    printfn "Hello World" 

let firstHundred = [0..100]



let getEvens x = 
    x % 2 = 0

let doubleValues x =
    x * 2


let sumOfFirstHundredEvensDoubled =
    [0..100]
    |> List.filter getEvens
    |> List.map doubleValues
    |> List.sum
