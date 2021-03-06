﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using ShootEmUp.UserInterface;
using ShootEmUp.Objects.Creatures.Enemies;

namespace ShootEmUp.Objects.Creatures.Player
{
    public class Player : Creature
    {
        float myElapsedTime = 0;
        float myDamage = 0;
        Vector2 myMoveDirection;
        Vector2 myRotationDirection;
        KeyboardState myPreviousKeyboardState;
        public const int myMaxHealth = 100;
        public int AccessScore { get; set; }
        public int AccessMoney { get; set; }

        public Player() :
            base(TextureLibrary.GetTexture("Ship"), new Rectangle(750, 750, 100, 100), myMaxHealth)
        {
            AccessSpeed = 350;
        }
        
        public override void Update(GameTime someTime)
        {
            float tempDeltaTime = (float)someTime.ElapsedGameTime.TotalSeconds;
            myElapsedTime += tempDeltaTime;
            myMoveDirection = new Vector2();
            KeyboardState aKeyboardState = Keyboard.GetState();

            Rectangle tempRectangle = AccessRectangle;

            KeyboardState tempKeyboardState = Keyboard.GetState();

            // Skeppets kontroller. Låter skeppet flytta i fyra riktningar med W-, A-, S- och D-tangenterna.

            if (aKeyboardState.IsKeyDown(Keys.W))
            {
                myMoveDirection.Y = -1;
            }

            if (aKeyboardState.IsKeyDown(Keys.A))
            {
                myMoveDirection.X = -1;
            }

            if (aKeyboardState.IsKeyDown(Keys.S))
            {
                myMoveDirection.Y = 1;
            }

            if (aKeyboardState.IsKeyDown(Keys.D))
            {
                myMoveDirection.X = 1;
            }

            if (myMoveDirection != Vector2.Zero)
            {
                myMoveDirection.Normalize();
                AccessPosition += myMoveDirection * AccessSpeed * tempDeltaTime;
            }

            // Låter skeppet skjuta kulor med Blanksteg. Kulan åker dit där spelaren tittar åt med trigonometri.

            if (aKeyboardState.IsKeyDown(Keys.Space) && myElapsedTime >= 0.35f)
            {
                myElapsedTime = 0;
                Game1.myObjects.Add(new Bullet(new Vector2((float)Math.Cos(AccessRotation), (float)Math.Sin(AccessRotation)), AccessRectangle.Location.ToVector2(), myDamage, 15, this));
            }

            // Låter skeppet skjuta missiler med Vänster-skifttangent.

            if (aKeyboardState.IsKeyDown(Keys.LeftShift) && myElapsedTime >= 1f)
            {
                myElapsedTime = 0;
                Game1.myObjects.Add(new Missile(new Vector2((float)Math.Cos(AccessRotation), (float)Math.Sin(AccessRotation)), AccessRectangle.Location.ToVector2(), myDamage, 7.5f, this));
            }

            // Låter skeppet rotera åt vänster håll med vänsterpilen.

            if (StartedPress(Keys.Left, tempKeyboardState))
            {
                AccessRotation += (float)MathHelper.PiOver4 * -1f;
                myRotationDirection = new Vector2((float)Math.Cos(AccessRotation), (float)Math.Sin(AccessRotation));
            }

            // Låter skeppet rotera åt höger håll med högerpilen.

            if (StartedPress(Keys.Right, tempKeyboardState))
            {
                AccessRotation += (float)MathHelper.PiOver4 * 1f;
                myRotationDirection = new Vector2((float)Math.Cos(AccessRotation), (float)Math.Sin(AccessRotation));
            }

            // Förstör skeppet när skeppet har noll eller färre hälsopoäng.

            if (AccessHealth <= 0)
            {
                Game1.myObjects.Remove(this);
                (Game1.myObjects.Where(x => x is DeathUI).First() as DeathUI).ShowDeathScreen();
            }

            myPreviousKeyboardState = tempKeyboardState;
        }

        private bool StartedPress(Keys aKey, KeyboardState aCurrentKeyboardState)
        {
            return (aCurrentKeyboardState.IsKeyDown(aKey) && !myPreviousKeyboardState.IsKeyDown(aKey));
        }
    }
}
