#!/usr/bin/bash

set -e

build=0
clean=0
args=("")

while [[ $# -gt 0 ]]; do
    case "$1" in
    -r | --rebuild)
        build=1
        clean=1
        shift
        ;;
    -c | --clean)
        clean=1
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

if [[ "$build" -ne 1 && "$clean" -ne 1 ]]; then
    build=1
fi

src_dir="${args[1]:?}"
out_dir="${args[2]:?}"
lib_dir="${args[3]:?}"

projects=()
projects+=("core:$lib_dir")
projects+=("lua:$src_dir/app/Lua/out")
projects+=("awesome:$src_dir/app/Awesome/out")
projects+=("arise:$src_dir/app/Arise/out")

sync_dir() {
    src="$1"
    dst="$2"
    shift 2
    echo "  -> Sync '$src' to '$dst'"
    rsync "$@" --recursive --checksum --update --delete "$src/" "$dst"
}

echo "==> Prepare '$out_dir'"
if [[ "$clean" -eq 1 ]]; then
    if [[ -d "$out_dir" ]]; then
        echo "  -> Clean '$out_dir'"
        rm -rf "$out_dir"
    fi
    for project in "${projects[@]}"; do
        project_name="${project%%:*}"
        project_src="${project#*:}"
        if [[ "$project_name" != "core" && -d "$project_src" ]]; then
            echo "  -> Clean '$project_src'"
            rm -rf "$project_src"
        fi
    done
fi

if [[ "$build" -eq 1 ]]; then
    echo "==> Copy files"
    mkdir -p "$out_dir/app"
    raw_exclude=()
    for project in "${projects[@]}"; do
        project_name="${project%%:*}"
        project_src="${project#*:}"
        project_dir="app/$project_name"
        sync_dir "$project_src" "$out_dir/$project_dir"
        raw_exclude+=("--exclude" "$project_dir")
    done
    sync_dir "$src_dir/raw" "$out_dir" "${raw_exclude[@]}"

    app_init_file="$out_dir/app/init.lua"
    echo "==> Create init file '$app_init_file'"
    {
        namespace="app"
        printf 'require("%s.debug")\n' "$namespace"
        printf 'require("%s.api")\n' "$namespace"
        printf '\n'
        for project in "${projects[@]}"; do
            project_name="${project%%:*}"
            namespace="app.$project_name"
            printf 'require("%s.manifest")("%s")\n' "$namespace" "$namespace"
        done
        
    } >"$app_init_file"
fi
