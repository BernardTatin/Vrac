#/usr/bin/env dash

. ./.config.sh

exec ${kernel}/bin/css-update.sh $(pwd) ${site_base}

