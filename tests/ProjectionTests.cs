namespace Cthangover.Mods.TileIsometric.Tests
{
    using Cthangover.Core.Mods.Testing;
    using Godot;
    /// <summary>Ground projection is invertible in every quadrant, before rounding to cells.</summary>
    public class ProjectionTests
    {
        [ModTest("projection/depth_anchor_preserves_art_geometry")]
        static void DepthAnchor(ModTestContext ctx)
        {
            var projection = new IsometricTileProjection(32);
            var visual = new Cthangover.Mods.TileRender.TileVisual { Bounds = new Rect2(1, 2, 2, 3), Anchor = new Vector2(2, 5), Upright = true };
            var before = projection.Place(visual);
            visual.DrawOrder = Cthangover.Mods.TileRender.TileDrawOrder.ByPosition; visual.SortAnchor = new Vector2(9, 10);
            var after = projection.Place(visual);
            ModAssert.True(before.Transform == after.Transform && before.Bounds == after.Bounds, "independent depth control does not shift the image");
            ModAssert.True(after.DepthSorted && after.Anchor != before.Anchor, "explicit depth anchor changes the sort position");
        }
        [ModTest("projection/ground_roundtrip_and_elevation")]
        static void GroundRoundtrip(ModTestContext ctx)
        {
            var projection = new IsometricTileProjection(32);
            for (var y = -4; y <= 4; y++)
            for (var x = -4; x <= 4; x++)
            {
                var point = new Vector2(x + 0.25f, y + 0.75f);
                var pixel = projection.Project(new Vector3(point.X, point.Y, 0));
                ModAssert.True(projection.Unproject(pixel).IsEqualApprox(point), "ground inverse including negative coordinates");
            }
            var ground = projection.Project(new Vector3(2, 3, 0));
            var above = projection.Project(new Vector3(2, 3, 1));
            ModAssert.CloseTo(32, ground.Y - above.Y, what: "one cell elevation");
            ModAssert.CloseTo(32, projection.Unit, what: "projection pixel scale");
            for (var direction = 0; direction < 4; direction++)
                ModAssert.True(projection.CharsetRow(direction) >= 0 && projection.CharsetRow(direction) < 4, "valid facing row");
        }
    }
}
