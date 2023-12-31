namespace HausdorffDistanceLibrary.Test
{
    public class HausdorffTests
    {
        [TestFixture]
        public class HausdorffDistanceTests
        {
            [Test]
            public void CalculateHausdorffDistance_SameFunctions_ReturnsZero()
            {
                // Arrange
                PiecewiseConstantFunction f1 = new();
                f1.Add(new Point(0.0, 0.0));
                f1.Add(new Point(0.5, 0.5));
                f1.Add(new Point(1.0, 1.0));

                PiecewiseConstantFunction f2 = new();
                f2.Add(new Point(0.0, 0.0));
                f2.Add(new Point(0.5, 0.5));
                f2.Add(new Point(1.0, 1.0));

                // Act
                double distance = f1.CalculateHausdorffDistance(f2);

                // Assert
                Assert.That(distance, Is.EqualTo(0.0));
            }

            [Test]
            public void CalculateHausdorffDistance_EmptyFunctions_ReturnsZero()
            {
                // Arrange
                PiecewiseConstantFunction f1 = new();
                PiecewiseConstantFunction f2 = new();

                // Act
                double distance = f1.CalculateHausdorffDistance(f2);

                // Assert
                Assert.That(distance, Is.EqualTo(0.0));
            }

            [Test]
            public void CalculateHausdorffDistance_FunctionsWithDifferentValues_ReturnsMaxDifference()
            {
                // Arrange
                PiecewiseConstantFunction f1 = new();
                f1.Add(new Point(0.0, 0.0));
                f1.Add(new Point(0.5, 0.5));
                f1.Add(new Point(1.0, 1.0));

                PiecewiseConstantFunction f2 = new();
                f2.Add(new Point(0.1, 0.1));
                f2.Add(new Point(0.6, 0.6));
                f2.Add(new Point(1.0, 1.0));

                // Act
                double distance = f1.CalculateHausdorffDistance(f2);

                // Assert
                Assert.That(distance, Is.EqualTo(0.1));
            }

            [Test]
            public void CalculateHausdorffDistance_FunctionsWithDifferentDomains_ReturnsMaxDifference()
            {
                // Arrange
                PiecewiseConstantFunction f1 = new();
                f1.Add(new Point(0.0, 0.0));
                f1.Add(new Point(0.5, 0.5));
                f1.Add(new Point(1.0, 1.0));

                PiecewiseConstantFunction f2 = new();
                f2.Add(new Point(0.2, 0.2));
                f2.Add(new Point(0.7, 0.7));
                f2.Add(new Point(1.2, 1.2));

                // Act
                double distance = f1.CalculateHausdorffDistance(f2);

                // Assert
                Assert.That(distance, Is.EqualTo(0.2));
            }

            [Test]
            public void CalculateHausdorffDistance_FunctionsWithOverlappingDomains_ReturnsMaxDifference()
            {
                // Arrange
                PiecewiseConstantFunction f1 = new();
                f1.Add(new Point(0.0, 0.0));
                f1.Add(new Point(0.5, 0.5));
                f1.Add(new Point(1.0, 1.0));

                PiecewiseConstantFunction f2 = new();
                f2.Add(new Point(0.2, 0.2));
                f2.Add(new Point(0.7, 0.7));
                f2.Add(new Point(1.0, 1.0));

                // Act
                double distance = f1.CalculateHausdorffDistance(f2);

                // Assert
                Assert.That(distance, Is.EqualTo(0.2));
            }

            [Test]
            public void CalculateHausdorffDistance_FunctionsWithDifferentNumberOfPoints_ReturnsMaxDifference()
            {
                // Arrange
                PiecewiseConstantFunction f1 = new();
                f1.Add(new Point(0.0, 0.0));
                f1.Add(new Point(0.5, 0.5));
                f1.Add(new Point(1.0, 1.0));

                PiecewiseConstantFunction f2 = new();
                f2.Add(new Point(0.0, 0.0));
                f2.Add(new Point(0.25, 0.25));
                f2.Add(new Point(0.5, 0.5));
                f2.Add(new Point(0.75, 0.75));
                f2.Add(new Point(1.0, 1.0));

                PiecewiseConstantFunction merged = PiecewiseConstantFunction.MergeDomains(f1, f2);

                // Act
                double distance1 = f1.CalculateHausdorffDistance(f2);
                double distance2 = merged.CalculateHausdorffDistance(f1);

                // Assert
                Assert.That(distance2, Is.EqualTo(distance1));
            }

            public void CalculateHausdorffDistance_MergedDomains_SameDistance()
            {
                // Arrange
                PiecewiseConstantFunction f1 = new();
                f1.Add(new Point(0.0, 0.0));
                f1.Add(new Point(0.5, 0.5));
                f1.Add(new Point(1.0, 1.0));

                PiecewiseConstantFunction f2 = new();
                f2.Add(new Point(0.25, 0.25));
                f2.Add(new Point(0.75, 0.75));

                PiecewiseConstantFunction merged = PiecewiseConstantFunction.MergeDomains(f1, f2);

                // Act
                double distance1 = f1.CalculateHausdorffDistance(f2);
                double distance2 = merged.CalculateHausdorffDistance(f2);

                // Assert
                Assert.That(distance2, Is.EqualTo(distance1));
            }

            [Test]
            public void CalculateHausdorffDistance_MergedDomains_ReturnsMaxDifference()
            {
                // Arrange
                PiecewiseConstantFunction f1 = new();
                f1.Add(new Point(0.0, 0.0));
                f1.Add(new Point(0.5, 0.5));
                f1.Add(new Point(1.0, 1.0));

                PiecewiseConstantFunction f2 = new();
                f2.Add(new Point(0.25, 0.25));
                f2.Add(new Point(0.75, 0.75));

                PiecewiseConstantFunction merged = PiecewiseConstantFunction.MergeDomains(f1, f2);

                // Act
                double distance1 = f1.CalculateHausdorffDistance(f2);
                double distance2 = merged.CalculateHausdorffDistance(f1);

                // Assert
                Assert.That(distance2, Is.EqualTo(distance1));
            }

            [Test]
            public void Add_AddLowerValue_Exception()
            {
                // Arrange
                PiecewiseConstantFunction f1 = new();
                f1.Add(new Point(0.0, 0.0));
                f1.Add(new Point(0.5, 0.5));
                Assert.Throws<Exception>(() => f1.Add(new Point(0.2, 1.0)));
            }

        }
    }
}