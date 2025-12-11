"""
Day 10: Reactor
"""


def setup(path="testinput_day11.dat") -> tuple[list[str], list[list[int]]]:
    """
    Parses input and returns a tuple consisting of:
    list[str] -> Vertices
    list[list[int]] -> Adjacency Matrix
    """
    input = []
    vertices = []
    seen_vertices = set()
    with open(path, "r") as f:
        for row in f:
            rowdata = row.strip()
            input.append(rowdata)
            # get vertice id's from both the leftmost columt, and the adjacency data.
            # we need to add all id's so we build the adjacency_matrix to the correct size
            vertice_id, adjacent_vertice_ids = rowdata.split(":")
            # We make this effort with the seen_vertices to ensure that we only try to add vertices to the list if they're not alreade there.
            # and the set has O(1) for "in" whereas the list has O(n) - making sure to not spend cpu cycles on list management if not needed.
            if vertice_id not in seen_vertices:
                seen_vertices.add(vertice_id)
                vertices.append(vertice_id)
            for id in adjacent_vertice_ids.strip().split(" "):
                if id not in seen_vertices:
                    seen_vertices.add(id)
                    vertices.append(id)
    number_of_vertices = len(vertices)

    # Now we build the adjacency matrix, which tells us which edges exist between which vertices
    # We could add weight here, but as for now there is nothing about this in the instructions so every "weight/cost" will be 1
    adjacency_matrix = [[0 for _ in range(number_of_vertices)] for v in range(number_of_vertices)]
    for graph_map in input:
        vertice_id, adjacency_data = graph_map.split(":")
        # find the index for the vertice for which we are adding edges
        vertice_index = vertices.index(vertice_id)
        for adj_id in adjacency_data.strip().split(" "):
            # find the index for the vertice which vertice_id is adjacent to
            adj_index = vertices.index(adj_id)
            adjacency_matrix[vertice_index][adj_index]=1
    

    return (vertices,adjacency_matrix)

def print_matrix(vertices:list[str], adj_matrix:list[list[int]]):
        print("...  | " + " | ".join(vertices))
        for i in range(len(vertices)):
            print(vertices[i], end="  |  ")
            print("  |  ".join(map(str,adj_matrix[i])))

if __name__ == "__main__":
    v,m = setup("testinput_day11.dat")
    print_matrix(v,m)
    
