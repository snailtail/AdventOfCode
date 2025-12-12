"""
    Class PresentShape for Advent of Code 2025 day 12
"""

from typing import Iterable

class PresentShape:
    def __init__(self, tile_block: str):
        self.tile_data = tile_block.strip().splitlines()
        assert len(self.tile_data)==4
        assert all(len(r) == 3 for r in self.tile_data[1:]) # all three rows of tile_data need to be 3 chars long
        assert self.tile_data[0].endswith(':')
        self.id = int(self.tile_data[0][:-1])
        self.shape_data = "".join(self.tile_data[1:])
        self.base_mask = self.parse_flat_3x3(self.shape_data)
        self.variants = self.generate_variants()
        assert self.base_mask in self.variants
        assert all(v.bit_count() == self.base_mask.bit_count() for v in self.variants)
        

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
    
    def mask_from_coords_3x3(self, coords: Iterable[tuple[int, int]]) -> int:
        mask = 0
        for x, y in coords:
            assert 0 <= x < 3 and 0 <= y < 3
            mask |= 1 << (y*3 + x)
        return mask
    
    def rotate_coord_90deg_clockwise(self,coord:tuple[int,int]) -> tuple[int,int]:
        x,y = coord
        (x, y) = (2 - y, x)
        return (x,y)

    def mirror_flip_coord(self,coord:tuple[int,int]) -> tuple[int,int]:
        # flip right < - > left
        x,y = coord
        (x, y) = (2 - x, y)
        return (x,y)
    
    def rotate_mask_90deg(self,mask: int) -> int:
        coords = self.coords_from_mask_3x3(mask)
        coords2 = [self.rotate_coord_90deg_clockwise(c) for c in coords]
        return self.mask_from_coords_3x3(coords2)
    
    def mirror_mask(self, mask: int) -> int:
        # flip right < - > left
        coords = self.coords_from_mask_3x3(mask)
        coords2 = [self.mirror_flip_coord(c) for c in coords]
        return self.mask_from_coords_3x3(coords2)

    def generate_variants(self) -> set[int]:
        # starta med m = base_mask
        # lägg in m, rot90(m), rot90(rot90(m)), rot90^3(m) i en set
        # gör samma sak för flip(base_mask) och dess 4 rotationer
        variants = set()
        m = self.base_mask
        for i in range(4):
            variants.add(m)
            m = self.rotate_mask_90deg(m)
        m = self.mirror_mask(self.base_mask)
        for i in range(4):
            variants.add(m)
            m = self.rotate_mask_90deg(m)
        

        return variants

    def __repr__(self):
        return f"PresentShape [id: {self.id}]\n[Tile data:\n{self.tile_data}\n]\n[shape_data:\n{self.shape_data}\n]\n[Base mask: {self.base_mask}]\n[Converted base mask:\n{self.render_mask_3x3(self.base_mask)}]"