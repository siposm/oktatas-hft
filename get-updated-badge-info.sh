#!/bin/bash

echo ">> shell script is running..."

commits=`git rev-list --all --count`
now=$(date +'%R %Y-%m-%d')
echo "{\"commits\":\"$commits\", \"last_push\":\"$now\"}" > badges.json