-module(role).
-include("game_pb.hrl").
-include("game.hrl").

-behaviour(gen_server).

%% api
-export([start/2, dispatch/2, stop/2]).

%% gen_server
-export([
        init/1,
        handle_call/3,
        handle_cast/2,
        handle_info/2,
        terminate/2,
        code_change/3
    ]).

dispatch(Name, Proto) ->
    PidName = list_to_atom(atom_to_list(?MODULE) ++ "_" ++ binary_to_list(Name)),
    gen_server:cast(PidName, {proto, Proto}).

stop(Name, Reason) ->
    PidName = list_to_atom(atom_to_list(?MODULE) ++ "_" ++ binary_to_list(Name)),
    gen_server:cast(PidName, {stop, Reason}).

%% api
start(Name, Reader) ->
    PidName = list_to_atom(atom_to_list(?MODULE) ++ "_" ++ binary_to_list(Name)),
    gen_server:start({local, PidName}, ?MODULE, [Name, Reader], []).

init([Name, Reader]) ->
    ets:insert(roles_online, #role{name = Name, reader = Reader}),
    lager:info("role init"),
    State = #role{name = Name, reader = Reader},
    {ok, State}.

handle_call(_Req, _From, State) ->
    {reply, ok, State}.

handle_cast({proto, Proto}, #role{reader = Reader} = State) ->
    lager:info("role route proto: ~p~n", [{Proto}]),
    RecordName = atom_to_list(element(1, Proto)),
    [_, M, F, _] = string:tokens(RecordName, "__"),
    Mod = list_to_atom("mod_" ++ M),
    Fun = list_to_atom(F),
    State1 = apply(Mod, Fun, [Proto, Reader, State]),

    {noreply, State1};
handle_cast({stop, Reason}, State) ->
    {stop, Reason, State};
handle_cast(Msg, State) ->
    lager:error("unhandled msg : ~p~n", [Msg]),
    {noreply, State}.

handle_info(Info, State) ->
    lager:error("unhandled into : ~p~n", [Info]),
    {noreply, State}.

terminate(_Reason, State) ->
    Name = State#role.name,
    ets:delete(roles_online, Name),
    ok.

code_change(_OldVsn, State, _Extra) ->
    {ok, State}.
