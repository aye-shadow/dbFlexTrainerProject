import os

def replace_connection_strings(folder_path, new_string):
    # Loop through all files in the folder
    for filename in os.listdir(folder_path):
        if filename.endswith(".cs"):
            file_path = os.path.join(folder_path, filename)
            # Open the file and read its contents
            with open(file_path, "r") as file:
                lines = file.readlines()
            # Check each line for the connection string and replace if found
            with open(file_path, "w") as file:
                for line in lines:
                    if 'Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True' in line:
                        line = line.replace('Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True', new_string)
                    file.write(line)

# Example usage:
folder_path = "."
new_connection_string = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"
replace_connection_strings(folder_path, new_connection_string)