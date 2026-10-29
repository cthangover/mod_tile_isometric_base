namespace Cthangover.Mods.TileIsometric
{
    using Cthangover.Mods.TileRender;
    /// <summary>Textured ground polygons and upright whole-object sprites share the same source atlases.</summary>
    public class IsometricRendererFactory : ITileRendererFactory
    {
        public string Id => "isometric";
        public ITileProjection Projection(int size) => new IsometricTileProjection(size);
        public ITileWorldPresentation Create() => new TileCanvasPresentation(this);
    }
}
