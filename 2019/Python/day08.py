# Parse the input string into a list of integers
with open('input_day08.txt') as f:
    digits = [int(x) for x in f.read().strip()]

# Determine the dimensions of the image
width = 25
height = 6

# Calculate the number of layers in the image
num_layers = len(digits) // (width * height)

# Initialize a list to hold the layers of the image
layers = []

# Split the list of digits into a list of layers
for i in range(num_layers):
    start = i * width * height
    end = start + width * height
    layers.append(digits[start:end])

# Find the layer with the fewest 0 digits
min_zeros = float('inf')
min_zeros_layer = None

for layer in layers:
    num_zeros = layer.count(0)
    if num_zeros < min_zeros:
        min_zeros = num_zeros
        min_zeros_layer = layer

# Calculate the number of 1 digits multiplied by the number of 2 digits
# in the layer with the fewest 0 digits
num_ones = min_zeros_layer.count(1)
num_twos = min_zeros_layer.count(2)

result = num_ones * num_twos

print(result)

# step 2

# Initialize a list to hold the layers of the image
layers = []

# Split the list of digits into a list of layers
for i in range(num_layers):
    start = i * width * height
    end = start + width * height
    layers.append(digits[start:end])

# Initialize a list to hold the decoded image
decoded_image = [2] * (width * height)

# Iterate through the layers in reverse order
for layer in reversed(layers):
    # Iterate through the pixels in the layer
    for i in range(len(layer)):
        # If the pixel is not transparent, update the corresponding
        # pixel in the decoded image
        if layer[i] != 2:
            decoded_image[i] = layer[i]

# Print the decoded image
for i in range(height):
    start = i * width
    end = start + width
    print(''.join(str(x) for x in decoded_image[start:end]))
