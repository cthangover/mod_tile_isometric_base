namespace Cthangover.Mods.TileIsometric
{
    using Cthangover.Mods.TileRender;
    using Godot;
    /// <summary>2:1 diamond projection. Triangles are drawing geometry; the logical four-neighbour grid stays square.</summary>
    public class IsometricTileProjection : ITileProjection
    {
        public float Unit { get; }
        public IsometricTileProjection(int size) { Unit = size > 0 ? size : throw new System.ArgumentOutOfRangeException(nameof(size)); }
        public Vector2 Project(Vector3 p) => new((p.X - p.Y) * Unit, (p.X + p.Y) * Unit * 0.5f - p.Z * Unit);
        public Vector2 Unproject(Vector2 p) => new((p.X * 0.5f + p.Y) / Unit, (p.Y - p.X * 0.5f) / Unit);
        public int CharsetRow(int facing) => facing switch { 0 => 1, 1 => 3, 2 => 0, _ => 2 };
        public TileVisualPlacement Place(TileVisual visual)
        {
            var anchor = TileDrawing.Project(this, visual.Anchor);
            if (visual.WorldQuad is { Length: 4 })
            {
                var points = new Vector2[4];
                for (var i = 0; i < 4; i++) points[i] = Project(visual.WorldQuad[i]);
                return TileVisualPlacement.FromQuad(points, anchor, visual.Upright);
            }
            if (visual.Upright)
            {
                var rect = new Rect2(anchor + (visual.Bounds.Position - visual.Anchor) * Unit, visual.Bounds.Size * Unit);
                var points = new[] { rect.Position, rect.Position + new Vector2(rect.Size.X, 0), rect.End,
                    rect.Position + new Vector2(0, rect.Size.Y) };
                return TileVisualPlacement.FromQuad(points, anchor, true);
            }
            return TileVisualPlacement.FromQuad(TileDrawing.CellPolygon(this, visual.Bounds), anchor, false);
        }
    }
}
