function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}

ps 70468;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 70468 > /dev/null;
done;

for child in $(list_child_processes 70480);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/ctw02447/Documents/Mestrado/DESOFS/desofs2024_M1C_1/DESOFT/DESOFT.Server/bin/Debug/net8.0/b6aa0fd617484ff185592fb5c51e1379.sh;
