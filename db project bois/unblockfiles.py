import os
import subprocess

def unblock_resx_files(directory):
    for root, dirs, files in os.walk(directory):
        for file in files:
            if file.endswith('.resx'):
                file_path = os.path.join(root, file)
                # Use PowerShell command to unblock the file
                subprocess.run(["powershell", "Unblock-File", file_path], capture_output=True, text=True)
                print(f"Unblocked: {file_path}")

# Replace 'path_to_your_directory' with the path to the directory containing your .resx files
directory_path = '.'
unblock_resx_files(directory_path)
