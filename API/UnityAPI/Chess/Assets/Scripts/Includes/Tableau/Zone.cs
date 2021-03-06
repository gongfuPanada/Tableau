using System;
using System.Collections;
using UnityEngine;

namespace Tableau {
    public abstract class Zone : MonoBehaviour {
        public Player owner;
        public GameObject prefab;
        // TODO public List</*unityAnimationType*/> animations; copied lol
        // TODO public List</*unitySoundType*/> sounds; copied lol

        public Zone() : this(null,null){
           
        }

        public Zone(Player owner, GameObject prefab) {
            this.owner = owner;
            this.prefab = prefab;
        }

        public abstract Piece GetPiece();
        public abstract void AddPiece(Piece p);
        public abstract void Clear();
        public abstract bool IsEmpty();
    }

    public class PieceZone : Zone {
        private Piece occupant;
        // TODO card/piece orientations? in subclasses?

        public PieceZone() : base()
        {
        }

        public PieceZone(Player owner, GameObject prefab, Piece occupant) : base(owner, prefab)
        {
            this.occupant = occupant;
        }
        
        public override Piece GetPiece() { return occupant; }
        
        public override void AddPiece(Piece p) { occupant = p; }

        public override void Clear() { occupant = null; }

        public override bool IsEmpty() { return occupant == null; }
    }
    
    // TODO custom class for zones w/ many cards? e.g. a deck zone but could be a piece
}