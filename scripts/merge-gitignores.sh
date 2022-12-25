#!/usr/bin/env zsh

# This script merges the *.gitignore files in the current directory into a single .gitignore file. 
# This is done to avoid having to maintain a single .gitignore file at the root of the repository
# which would be very large and cumbersome to maintain.

# list all *.gitignore files
gitignore_files=($(find . -maxdepth 1 -name '?*.gitignore'))

echo $gitignore_files ">" .gitignore

# empty the .gitignore file without newlines
echo -n > .gitignore

for gitignore_file in $gitignore_files; do
    # append the source file name
    echo "### $gitignore_file" >> .gitignore
    cat $gitignore_file >> .gitignore
    echo >> .gitignore
done
