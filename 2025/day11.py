"""
Day 11: Reactor
"""



from collections import deque
from functools import lru_cache


class ServerRack:
    def __init__(self,input: list[str]):
        self.servers = []
        seen_vertices = set()
        for rowdata in input:
            # get vertice id's from both the leftmost columt, and the adjacency data.
            # we need to add all id's so we build the adjacency_matrix to the correct size
            vertice_id, adjacent_vertice_ids = rowdata.split(":")
            # We make this effort with the seen_vertices to ensure that we only try to add vertices to the list if they're not alreade there.
            # and the set has O(1) for "in" whereas the list has O(n) - making sure to not spend cpu cycles on list management if not needed.
            if vertice_id not in seen_vertices:
                seen_vertices.add(vertice_id)
                self.servers.append(vertice_id)
            for id in adjacent_vertice_ids.strip().split(" "):
                if id not in seen_vertices:
                    seen_vertices.add(id)
                    self.servers.append(id)
            number_of_vertices = len(self.servers)

        # Now we build the adjacency matrix, which tells us which edges exist between which vertices
        # We could add weight here, but as for now there is nothing about this in the instructions so every "weight/cost" will be 1
        self.cable_matrix = [[0 for _ in range(number_of_vertices)] for v in range(number_of_vertices)]
        for graph_map in input:
            vertice_id, adjacency_data = graph_map.split(":")
            # find the index for the vertice for which we are adding edges
            vertice_index = self.servers.index(vertice_id)
            for adj_id in adjacency_data.strip().split(" "):
                # find the index for the vertice which vertice_id is adjacent to
                adj_index = self.servers.index(adj_id)
                self.cable_matrix[vertice_index][adj_index]=1
    
    
    def get_adjacent(self, node: str) -> list[str]:
        idx = self.servers.index(node)
        result = []
        row = self.cable_matrix[idx]
        for i, has_edge in enumerate(row):
            if has_edge:
                result.append(self.servers[i])
        return result

    @lru_cache(maxsize=None)
    def dfs_part2(self, node: str, seen_dac: bool, seen_fft: bool, end_node: str) -> int:
        if node == "dac":
            seen_dac = True
        if node == "fft":
            seen_fft = True

        if node == end_node:
            return 1 if (seen_dac and seen_fft) else 0

        total = 0
        for nxt in self.get_adjacent(node):
            total += self.dfs_part2(nxt, seen_dac, seen_fft, end_node)
        return total

    def get_path_count_part2(self, start_node="svr", end_node="out") -> int:
        self.dfs_part2.cache_clear()
        return self.dfs_part2(start_node, False, False, end_node)

    def get_path_count(self,starting_node: str, end_node='out') -> int:
        work = deque()
        work.append(starting_node)
        paths_to_end_node_counter = 0
        while work:
            current_node = work.pop()
            if current_node == end_node:     
                paths_to_end_node_counter += 1

            for adj_node in self.get_adjacent(current_node):
                work.append(adj_node) # add the adjacent node/server to the work stack

        return paths_to_end_node_counter


def setup(path="testinput_day11.dat") -> ServerRack:
    """
    Parses input and returns a ServerRack
    """
    input = []
    
    with open(path, "r") as f:
        for row in f:
            rowdata = row.strip()
            input.append(rowdata)
    server_matrix = ServerRack(input)
    return server_matrix

def print_matrix(vertices:list[str], adj_matrix:list[list[int]]):
        print("     | " + " | ".join(vertices))
        for i in range(len(vertices)):
            print(vertices[i], end="  |  ")
            print("  |  ".join(map(str,adj_matrix[i])))

if __name__ == "__main__":
    rack_p1 = setup("input_day11.dat")
    p1_count = rack_p1.get_path_count('you','out')
    print("Part 1:", p1_count)
    #rack_p2 = setup("testinput_day11_p2.dat")
    rack_p2 = setup("input_day11.dat")
    p2_count = rack_p2.get_path_count_part2('svr','out')
    print("Part 2:", p2_count)

    
