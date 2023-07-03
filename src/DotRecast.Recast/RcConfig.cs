/*
Copyright (c) 2009-2010 Mikko Mononen memon@inside.org
recast4j copyright (c) 2015-2019 Piotr Piastucki piotr@jtilia.org
DotRecast Copyright (c) 2023 Choi Ikpil ikpil@naver.com

This software is provided 'as-is', without any express or implied
warranty.  In no event will the authors be held liable for any damages
arising from the use of this software.
Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it
freely, subject to the following restrictions:
1. The origin of this software must not be misrepresented; you must not
 claim that you wrote the original software. If you use this software
 in a product, an acknowledgment in the product documentation would be
 appreciated but is not required.
2. Altered source versions must be plainly marked as such, and must not be
 misrepresented as being the original software.
3. This notice may not be removed or altered from any source distribution.
*/

using System;

namespace DotRecast.Recast
{
    public class RcConfig
    {
        public PartitionType partitionType;

        public bool useTiles;

        /** The width/depth size of tile's on the xz-plane. [Limit: &gt;= 0] [Units: vx] **/
        public int tileSizeX;

        public int tileSizeZ;

        /** The xz-plane cell size to use for fields. [Limit: &gt; 0] [Units: wu] **/
        public float cs;

        /** The y-axis cell size to use for fields. [Limit: &gt; 0] [Units: wu] **/
        public float ch;

        /** The maximum slope that is considered walkable. [Limits: 0 &lt;= value &lt; 90] [Units: Degrees] **/
        public float walkableSlopeAngle;

        /**
     * Minimum floor to 'ceiling' height that will still allow the floor area to be considered walkable. [Limit: &gt;= 3]
     * [Units: vx]
     **/
        public int walkableHeight;

        /** Maximum ledge height that is considered to still be traversable. [Limit: &gt;=0] [Units: vx] **/
        public int walkableClimb;

        /**
     * The distance to erode/shrink the walkable area of the heightfield away from obstructions. [Limit: &gt;=0] [Units:
     * vx]
     **/
        public int walkableRadius;

        /** The maximum allowed length for contour edges along the border of the mesh. [Limit: &gt;=0] [Units: vx] **/
        public int maxEdgeLen;

        /**
     * The maximum distance a simplfied contour's border edges should deviate the original raw contour. [Limit: &gt;=0]
     * [Units: vx]
     **/
        public float maxSimplificationError;

        /** The minimum number of cells allowed to form isolated island areas. [Limit: &gt;=0] [Units: vx] **/
        public int minRegionArea;

        /**
     * Any regions with a span count smaller than this value will, if possible, be merged with larger regions. [Limit:
     * &gt;=0] [Units: vx]
     **/
        public int mergeRegionArea;

        /**
     * The maximum number of vertices allowed for polygons generated during the contour to polygon conversion process.
     * [Limit: &gt;= 3]
     **/
        public int maxVertsPerPoly;

        /**
     * Sets the sampling distance to use when generating the detail mesh. (For height detail only.) [Limits: 0 or >=
     * 0.9] [Units: wu]
     **/
        public float detailSampleDist;

        /**
     * The maximum distance the detail mesh surface should deviate from heightfield data. (For height detail only.)
     * [Limit: &gt;=0] [Units: wu]
     **/
        public float detailSampleMaxError;

        public AreaModification walkableAreaMod;
        public bool filterLowHangingObstacles;
        public bool filterLedgeSpans;
        public bool filterWalkableLowHeightSpans;

        /** Set to false to disable building detailed mesh **/
        public bool buildMeshDetail;

        /** The size of the non-navigable border around the heightfield. [Limit: &gt;=0] [Units: vx] **/
        public int borderSize;

        /** Set of original settings passed in world units */
        public float minRegionAreaWorld;

        public float mergeRegionAreaWorld;
        public float walkableHeightWorld;
        public float walkableClimbWorld;
        public float walkableRadiusWorld;
        public float maxEdgeLenWorld;

        public RcConfig()
        {
        }

        /**
     * Non-tiled build configuration
     */
        public RcConfig(PartitionType partitionType, float cellSize, float cellHeight, float agentHeight, float agentRadius,
            float agentMaxClimb, float agentMaxSlope, int regionMinSize, int regionMergeSize, float edgeMaxLen,
            float edgeMaxError, int vertsPerPoly, float detailSampleDist, float detailSampleMaxError,
            AreaModification walkableAreaMod) : this(partitionType, cellSize, cellHeight, agentMaxSlope, true, true, true, agentHeight, agentRadius, agentMaxClimb,
            regionMinSize, regionMergeSize, edgeMaxLen, edgeMaxError, vertsPerPoly, detailSampleDist, detailSampleMaxError,
            walkableAreaMod, true)
        {
        }

        /**
     * Non-tiled build configuration
     */
        public RcConfig(PartitionType partitionType, float cellSize, float cellHeight, float agentMaxSlope,
            bool filterLowHangingObstacles, bool filterLedgeSpans, bool filterWalkableLowHeightSpans, float agentHeight,
            float agentRadius, float agentMaxClimb, int regionMinSize, int regionMergeSize, float edgeMaxLen, float edgeMaxError,
            int vertsPerPoly, float detailSampleDist, float detailSampleMaxError, AreaModification walkableAreaMod,
            bool buildMeshDetail) : this(false, 0, 0, 0, partitionType, cellSize, cellHeight, agentMaxSlope, filterLowHangingObstacles, filterLedgeSpans,
            filterWalkableLowHeightSpans, agentHeight, agentRadius, agentMaxClimb,
            regionMinSize * regionMinSize * cellSize * cellSize, regionMergeSize * regionMergeSize * cellSize * cellSize,
            edgeMaxLen, edgeMaxError, vertsPerPoly, buildMeshDetail, detailSampleDist, detailSampleMaxError, walkableAreaMod)
        {
            // Note: area = size*size in [Units: wu]
        }

        public RcConfig(bool useTiles, int tileSizeX, int tileSizeZ, int borderSize, PartitionType partitionType,
            float cellSize, float cellHeight, float agentMaxSlope, bool filterLowHangingObstacles, bool filterLedgeSpans,
            bool filterWalkableLowHeightSpans, float agentHeight, float agentRadius, float agentMaxClimb, float minRegionArea,
            float mergeRegionArea, float edgeMaxLen, float edgeMaxError, int vertsPerPoly, bool buildMeshDetail,
            float detailSampleDist, float detailSampleMaxError, AreaModification walkableAreaMod)
        {
            this.useTiles = useTiles;
            this.tileSizeX = tileSizeX;
            this.tileSizeZ = tileSizeZ;
            this.borderSize = borderSize;
            this.partitionType = partitionType;
            cs = cellSize;
            ch = cellHeight;
            walkableSlopeAngle = agentMaxSlope;
            walkableHeight = (int)Math.Ceiling(agentHeight / ch);
            walkableHeightWorld = agentHeight;
            walkableClimb = (int)Math.Floor(agentMaxClimb / ch);
            walkableClimbWorld = agentMaxClimb;
            walkableRadius = (int)Math.Ceiling(agentRadius / cs);
            walkableRadiusWorld = agentRadius;
            this.minRegionArea = (int)Math.Round(minRegionArea / (cs * cs));
            minRegionAreaWorld = minRegionArea;
            this.mergeRegionArea = (int)Math.Round(mergeRegionArea / (cs * cs));
            mergeRegionAreaWorld = mergeRegionArea;
            maxEdgeLen = (int)(edgeMaxLen / cellSize);
            maxEdgeLenWorld = edgeMaxLen;
            maxSimplificationError = edgeMaxError;
            maxVertsPerPoly = vertsPerPoly;
            this.detailSampleDist = detailSampleDist < 0.9f ? 0 : cellSize * detailSampleDist;
            this.detailSampleMaxError = cellHeight * detailSampleMaxError;
            this.walkableAreaMod = walkableAreaMod;
            this.filterLowHangingObstacles = filterLowHangingObstacles;
            this.filterLedgeSpans = filterLedgeSpans;
            this.filterWalkableLowHeightSpans = filterWalkableLowHeightSpans;
            this.buildMeshDetail = buildMeshDetail;
        }

        public static int CalcBorder(float agentRadius, float cs)
        {
            return 3 + (int)Math.Ceiling(agentRadius / cs);
        }
    }
}