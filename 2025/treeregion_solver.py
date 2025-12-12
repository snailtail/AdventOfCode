from present_shape import PresentShape
from tree_region import TreeRegion

class TreeRegionSolver:
    def __init__(self, shapes: list[PresentShape]):
        self.shapes = shapes
        self.shape_areas = tuple(s.base_mask.bit_count() for s in shapes)
        

    def can_fit(self, region: TreeRegion) -> bool:
        if region.quick_yes_by_slots():
            return True
        if region.quick_no_by_area(self.shape_areas):
            return False
        
        # if we ever get here - we need to implement more logic. 
        # turned out that we didn't at least not for my input.
        raise RuntimeError("Unexpected region - it requires more placement logic")
