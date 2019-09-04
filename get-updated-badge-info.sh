#!/bin/bash

echo "shell script is running..."

commits=`git rev-list --all --count`
now=$(date)
echo "{\"commits\":\"$commits\", \"last_push\":\"$now\"}" > badges.json