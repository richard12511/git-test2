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

    [<Test>]
    let ``When I call ProcessLines with an empty list of strings I should get an empty list`` () =
        let pieChartDrawer = new PieChartDrawer()

        let result = pieChartDrawer.ProcessLines([])

        Assert.IsTrue(result.IsEmpty)

    [<Test>]
    let ``When I call ProcessLines with "A, 1" and "B, 2" I should get tuples (A, 1) and (B, 2)`` () =
        let pieChartDrawer = new PieChartDrawer()

        let result = pieChartDrawer.ProcessLines(["A, 1"; "B, 2"])

        Assert.AreEqual(("A", 1) ,result.Item(0))
        Assert.AreEqual(("B", 2) ,result.Item(1))

    [<Test>]
    let ``When I call CalculateSum with (A, 1) and (B, 2) I should get 3`` () =
        let pieChartDrawer = new PieChartDrawer()

        let result = pieChartDrawer.CalculateSum([("A", 1); ("B", 2)])

        Assert.AreEqual(3, result)

    [<Test>]
    let ``When I call CalculateSum with (A, 10) and (B, 11) I should get 21`` () =
        let pieChartDrawer = new PieChartDrawer()

        let result = pieChartDrawer.CalculateSum([("A", 10); ("B", 11)])

        Assert.AreEqual(21, result)

    [<Test>]
    let ``When I call CalculateAngle with (part)3634 and (whole)5978 I should get 219`` () =
        let pieChartDrawer = new PieChartDrawer()

        let result = pieChartDrawer.CalculateAngle 3634 5978

        Assert.AreEqual(218, result)

    [<Test>]
    let ``When I call CalculateAngle with (part)767 and (whole)5978 I should get 46`` () =
        let pieChartDrawer = new PieChartDrawer()

        let result = pieChartDrawer.CalculateAngle 767 5978

        Assert.AreEqual(46, result)
        