"""
Day 12: Christmas Tree Farm
"""

from present_shape import PresentShape
from tree_region import TreeRegion
from treeregion_solver import TreeRegionSolver



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
    present_shapes, tree_regions = setup("input_day12.dat")
    p1_solver = TreeRegionSolver(present_shapes)
    quick_yes_by_slots=0
    total_count=0
    for region in tree_regions:
        total_count +=1
        result = p1_solver.can_fit(region)
        if result:
            quick_yes_by_slots +=1
    print(f"Part 1: (the only part for day 12): {quick_yes_by_slots}")
    

    
