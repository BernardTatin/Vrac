#/usr/bin/env dash

. ./.config.sh

page_name="$1"
shift
exec ${kernel}/bin/newpage.sh $page_name "$@"

