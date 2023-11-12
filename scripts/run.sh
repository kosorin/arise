#!/usr/bin/bash

set -e

display=':2.0'
size='1800x1000'
args=("")

while [[ $# -gt 0 ]]; do
    case "$1" in
    -d | --display)
        display="$2"
        shift
        shift
        ;;
    -s | --size)
        size="$2"
        shift
        shift
        ;;
    -*)
        echo "Unknown option $1" >&2
        exit 2
        ;;
    *)
        args+=("$1")
        shift
        ;;
    esac
done

awesome_config="${args[1]:?Missing rc.lua path}"
awesome_bin="${args[2]:?Missing bin path}"
awesome_libs=("${args[@]:3}")
if (( ! ${#awesome_libs[@]} )); then
    echo "Missing lib path" >&2
    exit 2
fi

echo "Starting Xephyr on $display"
Xephyr $display -ac -br -noreset -screen "$size" &
xephyr_pid=$!
while ! DISPLAY=$display xset q &>/dev/null; do sleep 0.1; done
echo "Xephyr pid: $xephyr_pid"

echo "Awesome bin: $awesome_bin"
echo "Awesome libs: ${awesome_libs[*]}"
echo "Awesome config: $awesome_config"
echo "Starting awesome"
echo "================================================================"
DEBUG=1 DISPLAY="$display" "$awesome_bin" -c "$awesome_config" -s "${awesome_libs[@]}"
echo "================================================================"
echo "Stopping Xephyr"
kill $xephyr_pid &>/dev/null
