day=$1;

if [[ "$1" == "" ]]; then
    current_date="$(date -d '+1 day' '+%d-%m')"
    day="$(echo $current_date | awk -F - '{print $1}')"
fi

cd "day-$day" && dotnet run