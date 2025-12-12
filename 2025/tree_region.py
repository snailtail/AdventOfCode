"""
    Class TreeRegion for Advent of Code 2025 day 12
"""

class TreeRegion:
    def __init__(self, region_data: str):
        self.raw = region_data.strip()
        self.region_data = region_data.split(": ")
        self.width, self.height = map(int,self.region_data[0].split("x"))
        self.counts_tuple = tuple(int(x) for x in self.region_data[1].split(" "))

        self.total_presents = sum(self.counts_tuple)
        self.area = self.width * self.height
        self.slots_3x3 = (self.width // 3) * (self.height // 3)

        assert self.width > 0 and self.height > 0
        assert all(c >= 0 for c in self.counts_tuple)
        assert len(self.counts_tuple) == 6
    
    # if we have enough area in this region for 3x3 slots for all the present counts, they will fit no matter what shape they are since they are never larger than 3x3
    def quick_yes_by_slots(self) -> bool: return self.total_presents <= self.slots_3x3

    # we don't need to test further if the total areas of the required shapes exceeds the total area available in the region
    # True means the region is a NO go
    def quick_no_by_area(self, shape_areas: tuple[int,...]) -> bool:
        required = sum(
            count * shape_areas[i]
            for i, count in enumerate(self.counts_tuple)
        )
        return required > self.area

    def __repr__(self):
        return f"*****\nTreeRegion w data:\n{self.region_data}\n[Width: {self.width}]\n[Height: {self.height}]\n[Counts: {self.counts_tuple}]\n[Raw: '{self.raw}']\n*****\n"