-module(role_manager).
-include("game_pb.hrl").
-include("game.hrl").

-behaviour(gen_server).

%% api
-export([start_link/0, create/2, dispatch/2]).

%% gen_server
-export([
        init/1,
        handle_call/3,
        handle_cast/2,
        handle_info/2,
        terminate/2,
        code_change/3
    ]).

%% api
start_link() ->
    gen_server:start_link({local, ?MODULE}, ?MODULE, [], []).

create(Name, From) ->
    gen_server:cast(?MODULE, {create, {Name, From}}).

dispatch(Pid, Proto) ->
    gen_server:cast(Pid, {proto, Proto}).

init([]) ->
    State = undefined,
    ets:new(roles_online, [public, set, named_table, {keypos, #role.name}]),
    {ok, State}.

handle_call(_Req, _From, State) ->
    {reply, ok, State}.

handle_cast({create, {Name, From}}, State) ->
    lager:info("gate connection, create role : ~p~n", [{From}]),
    {ok, Pid} = role:start(Name, From),
    LoginS2C = #m__role__login__s2c{},
    From ! {role_login, LoginS2C, Pid},
   {noreply, State};

handle_cast(Msg, State) ->
    lager:error("unhandled msg : ~p~n", [Msg]),
    {noreply, State}.

handle_info(Info, State) ->
    lager:error("unhandled into : ~p~n", [Info]),
    {noreply, State}.

terminate(_Reason, _State) ->
    ok.

code_change(_OldVsn, State, _Extra) ->
    {ok, State}.
