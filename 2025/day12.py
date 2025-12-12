"""
Day 12: Christmas Tree Farm
"""

class PresentShape:
    def __init__(self, tile_block: str):
        self.tile_data = tile_block.strip().splitlines()
        assert len(self.tile_data)==4
        assert all(len(r) == 3 for r in self.tile_data[1:]) # all three rows of tile_data need to be 3 chars long
        assert self.tile_data[0].endswith(':')
        self.id = int(self.tile_data[0][:-1])
        self.shape_data = "".join(self.tile_data[1:])
        self.base_mask = self.parse_flat_3x3(self.shape_data)
        

    def parse_flat_3x3(self,flat: str) -> int:
        """
        flat is 9 chars, row-major, e.g. '#####.##.' for:
        ###
        ##.
        ##.
        """
        flat = flat.strip()
        assert len(flat) == 9, f"Expected 9 chars, got {len(flat)}: {flat!r}"

        mask = 0
        for i, ch in enumerate(flat):
            if ch == "#":
                mask |= 1 << i
            elif ch == ".":
                pass
            else:
                raise ValueError(f"Unexpected char {ch!r} at index {i}")
        return mask
    
    def render_mask_3x3(self,mask: int) -> str:
        rows = []
        for y in range(3):
            row = []
            for x in range(3):
                i = y*3 + x
                row.append("#" if (mask >> i) & 1 else ".")
            rows.append("".join(row))
        return "\n".join(rows)

    def coords_from_mask_3x3(self, mask: int) -> tuple[tuple[int, int], ...]:
        """
            Return (x,y) for every set bit in a 3x3 mask.
            Bit index i = y*3 + x, with y=0 top row, x=0 left.
        """
        coords: list[tuple[int, int]] = []
        for i in range(9):
            if (mask >> i) & 1:
                y, x = divmod(i, 3)   # y=i//3, x=i%3
                coords.append((x, y))
        return tuple(coords)
    
    def mask_from_coords_3x3(self, coords: list[tuple[int, int]]) -> int:
        mask = 0
        for x, y in coords:
            assert 0 <= x < 3 and 0 <= y < 3
            mask |= 1 << (y*3 + x)
        return mask

    def __repr__(self):
        return f"PresentShape [id: {self.id}]\n[Tile data:\n{self.tile_data}\n]\n[shape_data:\n{self.shape_data}\n]\n[Base mask: {self.base_mask}]\n[Converted base mask:\n{self.render_mask_3x3(self.base_mask)}]"

class TreeRegion:
    def __init__(self, region_data: str):
        self.region_data = region_data

    def __repr__(self):
        return f"*****\nTreeRegion w data:\n{self.region_data}\n*****\n"

def setup(path="testinput_day12.dat"):
    """
    Parses input and returns tuple with list of present shapes and list of tree regions
    """
    present_shapes = []
    tree_regions = []

    with open(path, "r") as f:
        for row in f.read().split("\n\n"):
            rowdata = row.strip()
            if '#' in rowdata:
                present_shapes.append(PresentShape(rowdata.strip()))
            else:
                for region in rowdata.splitlines():
                    tree_regions.append(TreeRegion(region.strip()))        
    
    return present_shapes,tree_regions


if __name__ == "__main__":
    present_shapes, tree_regions = setup("testinput_day12.dat")
    for idx, present in enumerate(present_shapes):
        #print(f"**********\nIndex: {idx}, shape:\n{present}\n**********\n")
        #print(f"({present.id},'{present.shape_data}',{present.base_mask}),")
        print(present.coords_from_mask_3x3(present.base_mask))
        #print(present.mask_from_coords_3x3(present.coords_from_mask_3x3(present.base_mask)))

    #print(tree_regions)
    

    
