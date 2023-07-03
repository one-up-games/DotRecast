namespace DotRecast.Recast.DemoTool.Tools
{
    public class DynamicUpdateToolMode
    {
        public static readonly DynamicUpdateToolMode BUILD = new DynamicUpdateToolMode(0, "Build");
        public static readonly DynamicUpdateToolMode COLLIDERS = new DynamicUpdateToolMode(1, "Colliders");
        public static readonly DynamicUpdateToolMode RAYCAST = new DynamicUpdateToolMode(2, "Raycast");

        public static readonly DynamicUpdateToolMode[] Values = 
        {
            BUILD, COLLIDERS, RAYCAST
        };

        public int Idx { get; }
        public string Label { get; }

        private DynamicUpdateToolMode(int idx, string label)
        {
            Idx = idx;
            Label = label;
        }
    }
}