using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace ProgrammingLanguage.Client.Resources.Icons
{
    public static class FileIconContent
    {
        private static readonly Dictionary<string, string> _icons = new Dictionary<string, string>
        {
            {FileIconKey.MinusSmall,
                @"<DrawingGroup>
                  <DrawingGroup>
                    <DrawingGroup.ClipGeometry>
                      <RectangleGeometry Rect=""0,0,24,24"" />
                    </DrawingGroup.ClipGeometry>
                    <GeometryDrawing Brush=""{0}"">
                      <GeometryDrawing.Geometry>
                        <PathGeometry FillRule=""Nonzero"" Transform=""1,0,0,1,4,11"" Figures=""M1,0L15,0A1,1,0,0,1,15,2L1,2A1,1,0,0,1,1,0z"" />
                      </GeometryDrawing.Geometry>
                    </GeometryDrawing>
                  </DrawingGroup>
                </DrawingGroup>"
            },

            {FileIconKey.CloseWindowSmall,
                @"<DrawingGroup>
                  <DrawingGroup>
                    <DrawingGroup.ClipGeometry>
                      <RectangleGeometry Rect=""0,0,24,24"" />
                    </DrawingGroup.ClipGeometry>
                    <GeometryDrawing Brush=""{0}"">
                      <GeometryDrawing.Geometry>
                        <PathGeometry FillRule=""Nonzero"" Figures=""M18.3,5.71A1,1,0,0,0,16.89,5.71L12,10.59 7.11,5.7A1,1,0,0,0,5.7,7.11L10.59,12 5.7,16.89A1,1,0,0,0,7.11,18.3L12,13.41 16.89,18.3A1,1,0,0,0,18.3,16.89L13.41,12 18.3,7.11A1,1,0,0,0,18.3,5.71z"" />
                      </GeometryDrawing.Geometry>
                    </GeometryDrawing>
                  </DrawingGroup>
                </DrawingGroup>"
            },

            {FileIconKey.EditSmall,
                @"<DrawingGroup>
                  <DrawingGroup>
                    <DrawingGroup.ClipGeometry>
                      <RectangleGeometry Rect=""0,0,24,24"" />
                    </DrawingGroup.ClipGeometry>
                    <GeometryDrawing Brush=""{0}"">
                      <GeometryDrawing.Geometry>
                        <PathGeometry FillRule=""Nonzero"" Figures=""M3,17.46L3,20.5A0.5,0.5,0,0,0,3.5,21L6.54,21A0.469,0.469,0,0,0,6.89,20.85L17.81,9.94 14.06,6.19 3.15,17.1A0.491,0.491,0,0,0,3,17.46z M20.71,7.04A1,1,0,0,0,20.71,5.63L18.37,3.29A1,1,0,0,0,16.96,3.29L15.13,5.12 18.88,8.87 20.71,7.04z"" />
                      </GeometryDrawing.Geometry>
                    </GeometryDrawing>
                  </DrawingGroup>
                </DrawingGroup>"
            },
        };

        #region GetImageMethods
        public static DrawingImage GetDrawingImage(string fileIconKey, string colorBrush)
        {
            if (fileIconKey == null || !_icons.ContainsKey(fileIconKey))
            {
                throw new InvalidOperationException($"Invalid image key: {fileIconKey}");
            }
            string image = string.Format(_icons[fileIconKey], $"{{DynamicResource {colorBrush}}}");
            string xaml = $@"<DrawingImage xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
                                <DrawingImage.Drawing> {image} </DrawingImage.Drawing>
                            </DrawingImage>";
            DrawingImage result = XamlReader.Parse(xaml) as DrawingImage;
            return result;
        }

        public static ControlTemplate GetDrawingImageTemplate(string fileIconKey, string margin = null)
        {
            if (fileIconKey == null || !_icons.ContainsKey(fileIconKey))
            {
                throw new InvalidOperationException($"Invalid image key: {fileIconKey}");
            }

            string marginAttr = !string.IsNullOrWhiteSpace(margin) ? $@" Margin=""{margin}""" : "";
            string image = string.Format(_icons[fileIconKey], "{Binding Foreground, RelativeSource={RelativeSource TemplatedParent}}");
            string xaml = $@"<ControlTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" 
                                              xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
                                <Border BorderThickness=""0"" Background=""Transparent"">
                                    <Viewbox StretchDirection=""DownOnly"" Stretch=""Uniform""{marginAttr}>
                                        <Image x:Name=""Img"">
                                            <Image.Source>
                                                <DrawingImage>
                                                    <DrawingImage.Drawing>
                                                        {image}
                                                    </DrawingImage.Drawing>
                                                </DrawingImage>
                                            </Image.Source>
                                        </Image>
                                    </Viewbox>
                                </Border>
                        </ControlTemplate>";
            ControlTemplate result = XamlReader.Parse(xaml) as ControlTemplate;
            return result;
        }
        #endregion
    }
}