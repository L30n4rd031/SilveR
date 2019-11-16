﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SilveR.Models;

namespace SilveR.Migrations
{
    [DbContext(typeof(SilveRContext))]
    partial class SilveRContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("SilveR.Models.Analysis", b =>
                {
                    b.Property<int>("AnalysisID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnalysisGuid")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<int?>("DatasetID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DatasetName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DateAnalysed")
                        .HasColumnType("datetime");

                    b.Property<string>("HtmlOutput")
                        .HasColumnType("TEXT");

                    b.Property<string>("RProcessOutput")
                        .HasColumnType("TEXT");

                    b.Property<int>("ScriptID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tag")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("AnalysisID");

                    b.HasIndex("DatasetID");

                    b.HasIndex("ScriptID");

                    b.ToTable("Analyses");
                });

            modelBuilder.Entity("SilveR.Models.Argument", b =>
                {
                    b.Property<int>("ArgumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnalysisID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Value")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("ArgumentID");

                    b.HasIndex("AnalysisID");

                    b.ToTable("Arguments");
                });

            modelBuilder.Entity("SilveR.Models.Dataset", b =>
                {
                    b.Property<int>("DatasetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DatasetName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("TheData")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VersionNo")
                        .HasColumnType("INTEGER");

                    b.HasKey("DatasetID");

                    b.ToTable("Datasets");
                });

            modelBuilder.Entity("SilveR.Models.Script", b =>
                {
                    b.Property<int>("ScriptID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RequiresDataset")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ScriptDisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("ScriptFileName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ScriptID");

                    b.ToTable("Scripts");
                });

            modelBuilder.Entity("SilveR.Models.UserOption", b =>
                {
                    b.Property<int>("UserOptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AssessCovariateInteractions")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BWFill")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BWLine")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryBarFill")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ColourFill")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ColourLine")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("CovariateRegressionCoefficients")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DisplayLSMeansLines")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DisplayModelCoefficients")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DisplayPointLabels")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DisplaySEMLines")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ErrorBarWidth")
                        .HasColumnType("REAL");

                    b.Property<double>("FillTransparency")
                        .HasColumnType("REAL");

                    b.Property<string>("FontStyle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("GeometryDisplay")
                        .HasColumnType("INTEGER");

                    b.Property<double>("GraphicsBWHigh")
                        .HasColumnType("REAL");

                    b.Property<double>("GraphicsBWLow")
                        .HasColumnType("REAL");

                    b.Property<string>("GraphicsFont")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("GraphicsHeightJitter")
                        .HasColumnType("REAL");

                    b.Property<string>("GraphicsTextColour")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("GraphicsWidthJitter")
                        .HasColumnType("REAL");

                    b.Property<int>("GraphicsXAngle")
                        .HasColumnType("INTEGER");

                    b.Property<double>("GraphicsXHorizontalJust")
                        .HasColumnType("REAL");

                    b.Property<int>("GraphicsYAngle")
                        .HasColumnType("INTEGER");

                    b.Property<double>("GraphicsYVerticalJust")
                        .HasColumnType("REAL");

                    b.Property<int>("JpegHeight")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JpegWidth")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LegendPosition")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LegendTextColour")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LegendTextSize")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LineSize")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LineTypeDashed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LineTypeSolid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("OutputAnalysisOptions")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("OutputData")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("OutputPlotsInBW")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PaletteSet")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PlotResolution")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PointShape")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PointSize")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TitleSize")
                        .HasColumnType("INTEGER");

                    b.Property<int>("XAxisTitleFontSize")
                        .HasColumnType("INTEGER");

                    b.Property<int>("XLabelsFontSize")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YAxisTitleFontSize")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YLabelsFontSize")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserOptionID");

                    b.ToTable("UserOptions");
                });

            modelBuilder.Entity("SilveR.Models.Analysis", b =>
                {
                    b.HasOne("SilveR.Models.Dataset", "Dataset")
                        .WithMany("Analysis")
                        .HasForeignKey("DatasetID")
                        .HasConstraintName("FK_Analyses_Datasets");

                    b.HasOne("SilveR.Models.Script", "Script")
                        .WithMany("Analysis")
                        .HasForeignKey("ScriptID")
                        .HasConstraintName("FK_Analyses_Scripts")
                        .IsRequired();
                });

            modelBuilder.Entity("SilveR.Models.Argument", b =>
                {
                    b.HasOne("SilveR.Models.Analysis", "Analysis")
                        .WithMany("Arguments")
                        .HasForeignKey("AnalysisID")
                        .HasConstraintName("FK_Arguments_Analyses")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
