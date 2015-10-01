namespace LearningFSharpTests

open NUnit.Framework
open LearningFSharp
open System.Drawing

[<TestFixture>]
type PieChartDrawerTests() =

    [<Test>]
    member x.convertDataRow_GivenAComma1_ReturnsTupleAComma1() =
        let pieChartDrawer = new PieChartDrawer()

        let (resultTitle, resultValue) = pieChartDrawer.ConvertDataRow("A, 1")

        Assert.AreEqual(resultTitle, "A")
        Assert.AreEqual(resultValue, 1)