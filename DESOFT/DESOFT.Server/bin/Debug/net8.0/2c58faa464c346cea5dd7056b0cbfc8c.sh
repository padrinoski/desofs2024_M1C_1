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

ps 10415;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 10415 > /dev/null;
done;

for child in $(list_child_processes 10419);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/ctw02447/Documents/Mestrado/DESOFS/desofs2024_M1C_1/DESOFT/DESOFT.Server/bin/Debug/net8.0/2c58faa464c346cea5dd7056b0cbfc8c.sh;
