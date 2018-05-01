﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class JoinGame : MonoBehaviour {

	List<GameObject> roomList = new List<GameObject>();

	[SerializeField]
	private Text status;

	[SerializeField]
	private GameObject roomListPrefab;

	[SerializeField]
	private Transform roomListParent;

	private NetworkManager networkManager;

	void Start ()
	{
		networkManager = NetworkManager.singleton;
		if (networkManager.matchMaker == null)
		{
			networkManager.StartMatchMaker();
		}
		Refresh();
	}
	public void Refresh()
	{
		networkManager.matchMaker.ListMatches(0, 20, "", true, 0, 0, OnMatchList);
		status.text = "Loading...";
	}
	public void OnMatchList (bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
	{
		status.text = "";

		if(matchList == null)
		{
			status.text = "Couldn't get room list.";
			return;
		}
		ClearRoomList();
		foreach (MatchInfoSnapshot match in matchList)
		{
			GameObject _roomListItemGO = Instantiate(roomListPrefab);
			_roomListItemGO.transform.SetParent(roomListParent);

			ServerList _joingame = _roomListItemGO.GetComponent<ServerList>();
			if (_joingame != null)
			{
				_joingame.Setup(match, JoinRoom);
			}

			roomList.Add(_roomListItemGO);
		}
		if (roomList.Count == 0)
		{
			status.text = "You are the only one playing.";
		}
	}
	void ClearRoomList()
	{
		for (int i = 0 ; i < roomList.Count; i++)
		{
			Destroy(roomList[i]);
		}
		roomList.Clear();
	}

	public void JoinRoom (MatchInfoSnapshot match)
	{
		networkManager.matchMaker.JoinMatch(match.networkId, "", "","", 0, 0, networkManager.OnMatchJoined);
		ClearRoomList();
		status.text = "JOINING...";
	}

}