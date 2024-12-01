#!/bin/bash
# .env contains $session
source .env

if [[ "$1" == "-h" ]]; then
    echo "Usage: <day-year> in format dd-yyyy"
    elif [[ "$1" == "-h" ]]; then
    current_date="$(date -d '+1 day' '+%d-%m-%Y')"
    day="$(echo $current_date | awk -F - '{print $1}')"
    year="$(echo $current_date | awk -F - '{print $3}')"
else
    day="$(echo $1 | awk -F - '{print $1}')"
    year="$(echo $1 | awk -F - '{print $2}')"
    current_date="$day-12-$year"
fi

project_path="day-$day"
dotnet new console -n "$project_path"

day=$(expr $day + 0) # convert to int
echo "$day $year"
if [[ $day ]] && [[ ${#year} == 4 ]]; then
    echo "Initializing files for $day-12-$year"
    cd "$project_path" && \
    curl https://adventofcode.com/$year/day/$day/input \
    -H $"Cookie: session=${session}" \
    >> input.txt
fi
