#!/bin/sh

git checkout main
git pull -r
git checkout -b day$1

python3 ./getinput.py $1
cp template.py $1.py
touch ./data/$1test.dat
echo "# :christmas_tree: Advent of Code 2022 Day$1 :christmas_tree:" > $1.md
git add .
git commit -m "Add new day $1"
git push --set-upstream origin day$1