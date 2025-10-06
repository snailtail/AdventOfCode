import time
from aoc import inpututil as iu
import os
import re

class ExclusionZoneMap:
    
    def __init__(self, positiondata: list) -> None:
        self.sensors = set()
        self.beacons = set()
        
        for line in positiondata:
            matches = re.findall(r"([x-y]=(-?\d+))",line)
            (_, sensorX),(_, sensorY),(_,beaconX),(_,beaconY) = matches
            sensorX = int(sensorX)
            sensorY = int(sensorY)
            beaconX = int(beaconX)
            beaconY = int(beaconY)
            distance = abs(sensorX-beaconX) + abs(sensorY - beaconY)
            # Save the sensors position and distance to it's nearest beacon
            self.sensors.add((sensorX,sensorY,distance))
            # Save the beacons separately
            self.beacons.add((beaconX,beaconY))
            
    def can_contain_beacon(self, x,y):
        # A point on the map can't contain a beacon if it is <= the registered distance from any other sensor
        # Go through all sensors, check the distance from this point to the sensor.
        # If it is equal to or less than the distance registered for that sensor, then this point can't contain a beacon
        for (sx,sy,d) in self.sensors:
            dxy = abs(x-sx)+abs(y-sy)
            if dxy<=d:
                return False
        return True
    
    def step1(self):
        self.step1 = 0
        for x in range(-int(6e6),int(6e6)):
            y = int(2e6)
            if not self.can_contain_beacon(x,y) and (x,y) not in self.beacons:
                self.step1 += 1
    
    def step2(self):
        self.step2 = 0
        found = False
        for (sensor_x,sensor_y,distance) in self.sensors:
            # check all points that are 1 more than distance from (sensor_x,sensor_y)
            for dx in range(distance+2):
                dy = (distance+1)-dx
                distance_checks = [(1,1),(-1,-1),(-1,1),(1,-1)]
                for signal_x,signal_y in distance_checks:
                    x = sensor_x+(dx*signal_x)
                    y = sensor_y+(dy*signal_y)
                    # Only possible within the defined square och 4x4 million points
                    if not(0<=x<=4000000 and 0<=y<=4000000):
                        continue
                    if map.can_contain_beacon(x,y) and (not found):
                        self.step2 = x*4000000 + y
                        found = True
                        return True


cold_start = time.time()
file=os.path.basename(__file__).replace('.py','')
util = iu()
lines = util.GetLines(file, test=False)
map = ExclusionZoneMap(lines)

step1_start = time.time()
map.step1()
step1_complete = time.time()
print(f"Step 1: {map.step1}")


step2_start = time.time()
map.step2()
print(f"Step 2: {map.step2}")
finish = time.time()

print(f"Cold start to step1 start: {step1_start - cold_start}")
print(f"Step1 start to step1 finish: {step1_complete - step1_start}")
print(f"Step2 start to finish: {finish - step2_start}")

