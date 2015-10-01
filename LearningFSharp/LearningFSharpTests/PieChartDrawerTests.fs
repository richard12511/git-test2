namespace LearningFSharpTests

open NUnit.Framework
open LearningFSharp
open System.Drawing

[<TestFixture>]
module PieChartDrawerTests =

    [<Test>]
    let ``When I call ConvertDataRow with "A, 1" I should get a tuple (A,1)`` () =
        let pieChartDrawer = new PieChartDrawer()

        let (resultTitle, resultValue) = pieChartDrawer.ConvertDataRow("A, 1")

        Assert.AreEqual(resultTitle, "A")
        Assert.AreEqual(resultValue, 1)

    [<Test>]
    let ``When I call ConvertDataRow with "A, 1, B, 2" I should get a tuple (A,1)`` () =
        let pieChartDrawer = new PieChartDrawer()

        let (resultTitle, resultValue) = pieChartDrawer.ConvertDataRow("A, 1, B, 2")

        Assert.AreEqual(resultTitle, "A")
        Assert.AreEqual(resultValue, 1)

    [<Test]
    let ``When I call ConvertDataRow with "A" I should get a failure exception`` () =
        let pieChartDrawer = new PieChartDrawer()

        let (resultTitle, resultValue) = pieChartDrawer.ConvertDataRow("A")

        Assert.Fail("bad")