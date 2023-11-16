namespace Awesome.UI;

public static class Shape
{
    public static ShapeHandler Rectangle()
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.rectangle(context, width, height)
            ]]*/
        };
    }

    public static ShapeHandler RoundedRectangle(float radius, bool topLeft = true, bool topRight = true, bool bottomRight = true, bool bottomLeft = true)
    {
        if (topLeft && topRight && bottomRight && bottomLeft)
        {
            return (context, width, height) =>
            {
                /*[[
                    Lapi.gears.shape.rounded_rect(context, width, height, radius)
                ]]*/
            };
        }
        else
        {
            return (context, width, height) =>
            {
                /*[[
                    Lapi.gears.shape.rounded_rect(context, width, height, topLeft, topRight, bottomRight, bottomLeft, radius)
                ]]*/
            };
        }
    }

    public static ShapeHandler RoundedBar()
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.rounded_bar(context, width, height)
            ]]*/
        };
    }

    public static ShapeHandler Squircle(float rate, float delta, bool topLeft = true, bool topRight = true, bool bottomRight = true, bool bottomLeft = true)
    {
        if (topLeft && topRight && bottomRight && bottomLeft)
        {
            return (context, width, height) =>
            {
                /*[[
                    Lapi.gears.shape.squircle(context, width, height, rate, delta)
                ]]*/
            };
        }
        else
        {
            return (context, width, height) =>
            {
                /*[[
                    Lapi.gears.shape.squircle(context, width, height, topLeft, topRight, bottomRight, bottomLeft, rate, delta)
                ]]*/
            };
        }
    }

    public static ShapeHandler Circle(float? radius = null)
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.circle(context, width, height, radius)
            ]]*/
        };
    }

    public static ShapeHandler InfoBubble(float? cornerRadius = null, float? arrowSize = null, float? arrowPosition = null)
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.infobubble(context, width, height, cornerRadius, arrowSize, arrowPosition)
            ]]*/
        };
    }

    public static ShapeHandler RectangularTag(float? arrowLength = null)
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.rectangular_tag(context, width, height, arrowLength)
            ]]*/
        };
    }

    public static ShapeHandler Powerline(float? arrowDepth = null)
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.powerline(context, width, height, arrowDepth)
            ]]*/
        };
    }

    public static ShapeHandler Pie(float? startAngle = null, float? endAngle = null, float? radius = null)
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.pie(context, width, height, startAngle, endAngle, radius)
            ]]*/
        };
    }

    public static ShapeHandler Arc(float? thickness = null, float? startAngle = null, float? endAngle = null, bool? startRounded = null, bool? endRounded = null)
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.arc(context, width, height, thickness, startAngle, endAngle, startRounded, endRounded)
            ]]*/
        };
    }

    public static ShapeHandler SolidRectangleShadow(float? xOffset = null, float? yOffset = null)
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.solid_rectangle_shadow(context, width, height, xOffset, yOffset)
            ]]*/
        };
    }

    public static ShapeHandler RadialProgress(float percent, bool hideLeft)
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.radial_progress(context, width, height, percent, hideLeft)
            ]]*/
        };
    }

    public static ShapeHandler Arrow(float? headWidth = null, float? shaftWidth = null, float? shaftLength = null)
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.rectangular_tag(context, width, height, headWidth, shaftWidth, shaftLength)
            ]]*/
        };
    }

    public static ShapeHandler Star(int n)
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.star(context, width, height, n)
            ]]*/
        };
    }

    public static ShapeHandler Cross(float? thickness = null)
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.cross(context, width, height, thickness)
            ]]*/
        };
    }

    public static ShapeHandler Hexagon()
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.hexagon(context, width, height)
            ]]*/
        };
    }

    public static ShapeHandler Octagon(float cornerRadius)
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.octogon(context, width, height, cornerRadius)
            ]]*/
        };
    }

    public static ShapeHandler Diamond()
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.losange(context, width, height)
            ]]*/
        };
    }

    public static ShapeHandler IsoscelesTriangle()
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.isosceles_triangle(context, width, height)
            ]]*/
        };
    }

    public static ShapeHandler Parallelogram(float? baseWidth = null)
    {
        return (context, width, height) =>
        {
            /*[[
                Lapi.gears.shape.parallelogram(context, width, height, baseWidth)
            ]]*/
        };
    }
}
