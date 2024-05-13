import os
import zipfile

def zip_cs_files(folder_path, zip_file_name):
    # Get a list of all .cs files in the folder
    cs_files = [f for f in os.listdir(folder_path) if os.path.isfile(os.path.join(folder_path, f)) and f.endswith('.cs')]
    
    # Check if there are any .cs files
    if not cs_files:
        print("No .cs files found in the folder.")
        return
    
    # Create a zip file
    with zipfile.ZipFile(zip_file_name, 'w') as zipf:
        # Add each .cs file to the zip file
        for cs_file in cs_files:
            file_path = os.path.join(folder_path, cs_file)
            zipf.write(file_path, os.path.basename(file_path))

    print(f"All .cs files in '{folder_path}' zipped into '{zip_file_name}' successfully.")

# Example usage:
folder_path = "."
zip_file_name = "i220899_i221281_i221158_Project"
zip_cs_files(folder_path, zip_file_name)
