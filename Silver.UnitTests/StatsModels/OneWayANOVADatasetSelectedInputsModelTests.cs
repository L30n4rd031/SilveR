using SilveR.Models;
using SilveR.StatsModels;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Silver.UnitTests.StatsModels
{
    public class OneWayANOVADatasetBasedInputsModelTests
    {
        [Fact]
        public void ScriptFileName_ReturnsCorrectString()
        {
            //Arrange
            OneWayANOVADatasetBasedInputsModel sut = new OneWayANOVADatasetBasedInputsModel();

            //Act
            string result = sut.ScriptFileName;

            //Assert
            Assert.Equal("OneWayANOVADatasetBasedInputs", result);
        }

        [Fact]
        public void SignificancesList_ReturnsCorrectList()
        {
            //Arrange
            OneWayANOVADatasetBasedInputsModel sut = new OneWayANOVADatasetBasedInputsModel();

            //Act
            IEnumerable<string> result = sut.SignificancesList;

            //Assert
            Assert.IsAssignableFrom<IEnumerable<string>>(result);
            Assert.Equal(new List<string>() { "0.1", "0.05", "0.01", "0.001" }, result);
        }


        [Fact]
        public void GetArguments_ReturnsCorrectArguments()
        {
            //Arrange
            OneWayANOVADatasetBasedInputsModel sut = GetModel();

            //Act
            List<Argument> result = sut.GetArguments().ToList();

            //Assert
            var graphTitle = result.Single(x => x.Name == "GraphTitle");
            Assert.Null(graphTitle.Value);

            var plottingRangeType = result.Single(x => x.Name == "PlottingRangeType");
            Assert.Equal("SampleSize", plottingRangeType.Value);

            var powerFrom = result.Single(x => x.Name == "PowerFrom");
            Assert.Null(powerFrom.Value);

            var powerTo = result.Single(x => x.Name == "PowerTo");
            Assert.Null(powerTo.Value);

            var response = result.Single(x => x.Name == "Response");
            Assert.Equal("Resp1", response.Value);

            var sampleSizeFrom = result.Single(x => x.Name == "SampleSizeFrom");
            Assert.Equal("6", sampleSizeFrom.Value);

            var sampleSizeTo = result.Single(x => x.Name == "SampleSizeTo");
            Assert.Equal("15", sampleSizeTo.Value);

            var significance = result.Single(x => x.Name == "Significance");
            Assert.Equal("0.05", significance.Value);

            var treatment = result.Single(x => x.Name == "Treatment");
            Assert.Equal("Treat2", treatment.Value);
        }

        [Fact]
        public void LoadArguments_ReturnsCorrectArguments()
        {
            //Arrange
            OneWayANOVADatasetBasedInputsModel sut = new OneWayANOVADatasetBasedInputsModel();

            List<Argument> arguments = new List<Argument>();
            arguments.Add(new Argument { Name = "GraphTitle" });
            arguments.Add(new Argument { Name = "PlottingRangeType", Value = "SampleSize" });
            arguments.Add(new Argument { Name = "PowerFrom" });
            arguments.Add(new Argument { Name = "PowerTo" });
            arguments.Add(new Argument { Name = "Response", Value = "Resp1" });
            arguments.Add(new Argument { Name = "SampleSizeFrom", Value = "6" });
            arguments.Add(new Argument { Name = "SampleSizeTo", Value = "15" });
            arguments.Add(new Argument { Name = "Significance", Value = "0.05" });
            arguments.Add(new Argument { Name = "Treatment", Value = "Treat2" });

            Assert.Equal(9, arguments.Count);

            //Act
            sut.LoadArguments(arguments);

            //Assert
            Assert.Null(sut.GraphTitle);
            Assert.Equal(PlottingRangeTypeOption.SampleSize, sut.PlottingRangeType);
            Assert.Null(sut.PowerFrom);
            Assert.Null(sut.PowerTo);
            Assert.Equal("Resp1", sut.Response);
            Assert.Equal(6, sut.SampleSizeFrom);
            Assert.Equal(15, sut.SampleSizeTo);
            Assert.Equal("0.05", sut.Significance);
            Assert.Equal("Treat2", sut.Treatment);
        }

        [Fact]
        public void GetCommandLineArguments_ReturnsCorrectString()
        {
            //Arrange
            OneWayANOVADatasetBasedInputsModel sut = GetModel();

            //Act
            string result = sut.GetCommandLineArguments();

            //Assert
            Assert.Equal("DatasetValues Resp1 Treat2 0.05 SampleSize 6 15 NULL", result);
        }


        private OneWayANOVADatasetBasedInputsModel GetModel()
        {
            var model = new OneWayANOVADatasetBasedInputsModel
            {
                GraphTitle = null,
                PlottingRangeType = PlottingRangeTypeOption.SampleSize,
                PowerFrom = null,
                PowerTo = null,
                Response = "Resp1",
                SampleSizeFrom = 6,
                SampleSizeTo = 15,
                Significance = "0.05",
                Treatment = "Treat2"
            };

            return model;
        }
    }
}