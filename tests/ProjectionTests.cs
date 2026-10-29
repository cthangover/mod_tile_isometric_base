namespace Cthangover.Mods.TileIsometric.Tests
{
    using Cthangover.Core.Mods.Testing;
    using Godot;
    /// <summary>Ground projection is invertible in every quadrant, before rounding to cells.</summary>
    public class ProjectionTests
    {
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
