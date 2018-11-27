﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DemoStyleEnd : MonoBehaviour {

    int round = -1;
    int chain = 0;

    RoundDataManager rdm;

    public TextMeshProUGUI guessText;

    HostGame hg;
     
    GameManager gm;

    PlayerManager pm;

    UIManager um;

    void Start() {
        rdm = FindObjectOfType<RoundDataManager>();
        hg = FindObjectOfType<HostGame>();
        gm = FindObjectOfType<GameManager>();
        pm = FindObjectOfType<PlayerManager>();
        um = FindObjectOfType<UIManager>();
        um.PocketReset();
    }


    public void Next() {
        um.PocketReset();
        round++;
        //guessText.text = "";
        if (hg.numberOfPlayers < round) {
            chain++;
            round = 0;
            guessText.text = "Next chain of events looks like this:";
            if(chain >= hg.numberOfPlayers) {
                chain = 0; //Teksti thats it folks ja nappi play again?
            }
        }

        var ch = rdm.chains[chain];

        if (round % 2 == 0) {
            if (round == 0) {
                guessText.text = pm.playerDataList[((chain - 1 + hg.numberOfPlayers) % hg.numberOfPlayers)].playerName + " was asked to draw " + ch.guesses[0];
            } else {
                guessText.text = "Which " + pm.playerDataList[(chain - round + hg.numberOfPlayers) % hg.numberOfPlayers].playerName + " deciphered as:\n " + ch.guesses[round / 2];
            }
               // (chain % hg.numberOfPlayers - 1)


        } else {
            var pics = rdm.chains[chain].pictures;
            if (round - 1 == 0) {
                guessText.text = "to which this " + pm.playerDataList[((chain - 1 + hg.numberOfPlayers) % hg.numberOfPlayers)].playerName + " drew as";
                um.ShowPicture(pics[0]);
            } else {
                guessText.text = "which " + pm.playerDataList[(chain - round + hg.numberOfPlayers) % hg.numberOfPlayers].playerName + " drew as";
                um.ShowPicture(pics[(round - 1) / 2]);
            }
        }
    }

    public void Previous() {
        round--;
        um.PocketReset();
        //guessText.text = "";

        if(round < 0) {
            chain--;
            round = hg.numberOfPlayers;
            //guessText.text = "Next chain of events looks like this:";
            if(chain < 0 ) {
                chain = hg.numberOfPlayers - 1; //Teksti thats it folks ja nappi play again?
            }
        }

        var ch = rdm.chains[chain];

        if(round % 2 == 0) {

            if(round == 0) {
                guessText.text = pm.playerDataList[((chain - 1 + hg.numberOfPlayers) % hg.numberOfPlayers)].playerName + " was asked to draw " + ch.guesses[0];
            } else {
                guessText.text = "Which " + pm.playerDataList[(chain - round + hg.numberOfPlayers) % hg.numberOfPlayers].playerName + " deciphered as:\n " + ch.guesses[round / 2];
            }
            // (chain % hg.numberOfPlayers - 1)


        } else {
            var pics = rdm.chains[chain].pictures;
            if(round - 1 == 0) {
                guessText.text = "to which this " + pm.playerDataList[((chain - 1 + hg.numberOfPlayers) % hg.numberOfPlayers)].playerName + " drew as";
                um.ShowPicture(pics[0]);
            } else {
                guessText.text = "which " + pm.playerDataList[(chain - round + hg.numberOfPlayers) % hg.numberOfPlayers].playerName + " drew as";
                um.ShowPicture(pics[(round - 1) / 2]);
            }
        }
    }
}