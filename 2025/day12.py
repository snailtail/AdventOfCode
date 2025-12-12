"""
Day 12: ???
"""

class PresentShape:
    def __init__(self, tile_data: list[str]):
        self.tile_data = tile_data

    def __repr__(self):
        return f"PresentShape w data:\n{self.tile_data}\n"

class TreeRegion:
    def __init__(self, region_data: str):
        self.region_data = region_data

    def __repr__(self):
        return f"*****\nTreeRegion w data:\n{self.region_data}\n*****\n"

def setup(path="testinput_day12.dat"):
    """
    Parses input and returns ....?
    """
    present_shapes = []
    tree_regions = []

    with open(path, "r") as f:
        for row in f.read().split("\n\n"):
            rowdata = row.strip()
            if '#' in rowdata:
                present_shapes.append(PresentShape(rowdata))
                print("This is a shape!")
            else:
                for region in rowdata.split("\n"):
                    tree_regions.append(TreeRegion(region.strip()))
            
            print("Rowdata: [\n",rowdata,"\n]\n")
    
    return present_shapes,tree_regions


if __name__ == "__main__":
    present_shapes, tree_regions = setup("input_day12.dat")
    print(present_shapes)
    print(tree_regions)
    

    
