#!/bin/bash
PYTHONPATH=python
ROOTDIR=`cd $(dirname $0); pwd`

cd $ROOTDIR
$PYTHONPATH ./script/build_erlang.py ./proto/game.proto ./erlang/game_pb.hrl ./erlang/game_pb.erl

cp ./erlang/game_pb.erl ../server/gate/src/
cp ./erlang/game_pb.hrl ../server/gate/include/

cp ./erlang/game_pb.erl ../server/game/src/
cp ./erlang/game_pb.hrl ../server/game/include/

mv ./erlang/game_pb.erl ../server/battle/src/
mv ./erlang/game_pb.hrl ../server/battle/include/

#chmod a-w $ROOTDIR/../server/src/game_pb.erl
#chmod a-w $ROOTDIR/../server/include/game_pb.hrl
echo "ok"
