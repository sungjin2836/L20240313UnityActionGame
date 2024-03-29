﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TouchPad : MonoBehaviour
{
    //UI에서 사용하는 고유의 트랜스폼 RectTransform 좌표
    private RectTransform _touchPad;

    //터치 입력 중에 방향 컨트롤러의 영역 안에 있는 입력을 구분하기 위한 고윺 식별 코드(아이디)
    private int _touchId = -1;

    //입력이 시작되는 좌표
    private Vector3 _starPos = Vector3.zero; // 0

    //방향 컨트롤러가 원으로 움직이는 반지름
    private float _dragRadius = 0.0f;

    //플레이어의 움직임을 관리하는 Playermovement와 연결해
    //방향키가 전달되면 캐릭터에게 신호를 보내는 역할
    public PlayerMovement _player;

    //버튼이 눌렸는지 체크하는 변수
    private bool _buttonPressed = false;

    private void Start()
    {
        _touchPad = GetComponent<RectTransform>();
        _starPos = _touchPad.position;
        _dragRadius = 60.0f;

    }

    public void ButtonDown()
    {
        Debug.Log("버튼 다운");
        _buttonPressed = true;
    }

    public void ButtonUp()
    {
        _buttonPressed = false;
        HandleInput(_starPos);
    }

    private void FixedUpdate()
    {
        //일반적인 경우 터치패드로 작업함(모바일)
        HandletouchInput();
        //#if는 조건부 컴파일을 구현하기 위한 전처리기
        //유니티 에디터 / 웹 / 인게임에서 마우스 클릭으로 작업함
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_STANDALONE_WIN ||UNITY_WEBGL
        HandleInput(Input.mousePosition);
#endif
    }

    void HandletouchInput()
    {
        int i = 0; // 터치 아이디를 매기기 위한 변수

        //터치가 1번이라도 들어오면 실행
        if(Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {
                i++; //터치 번호 증가

                //입력한 터치 값으로 좌표를 계산
                Vector3 touchPos = new Vector3(touch.position.x, touch.position.y);

                //터치 입력이 방금 시작되었다면
                if(touch.phase == TouchPhase.Began)
                {
                    //그 터치가 현재의 방향키 범위 내에 존재하는 경우
                    if(touch.position.x <= (_starPos.x + _dragRadius))
                    {
                        //이 터치 값을 기준으로 컨트롤러를 조작
                        _touchId = i;
                    }
                }
                //터치 입력이 움직였거나, 가만히 있는 상황일 경우
                if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    if(_touchId == i)
                    {
                        HandleInput(touchPos);
                    }
                }
                //터치 입력이 끝난 경우
                if(touch.phase == TouchPhase.Ended)
                {
                    //아이디 해제
                    if(_touchId == i)
                    {
                        _touchId = -1;
                    }
                }
            }
        }
    }

    void HandleInput(Vector3 input)
    {
        //버튼이 눌려져 있는 상황일 경우
        if(_buttonPressed)
        {
            //방향 컨트롤러의 기준 좌표부터 입력받은 좌표가 얼마나 떨어져있는지를 구함
            Vector3 diffVector = (input - _starPos);

            //sqrMagnitude는 두 점간의 거리의 제곱에 루트를 더한 값
            // 비슷한 개념 Vector3.Distance (연산속도가 느린 편), 대신 건축물 같은 정교한 값 구할때 사용
            //sqlrMagnitude는 단순하게 두 점 사이의 거리를 구할 때 사용
            //정확한 거리를 체크하는게 아닌 값의 크고 작은 지만 판단하는 식
            if (diffVector.sqrMagnitude > _dragRadius * _dragRadius)
            {
                diffVector.Normalize(); // 방향 벡터의 거리를 1로 설정함(정규화)
                //각 위치별 거리를 1로 고정

                //방향 컨트롤러는 최대치만큼 이동합니다.
                _touchPad.position = _starPos + diffVector * _dragRadius;
            }
            else
            {
                //입력 지점과 기준 좌표가 최대치보다 크지 않을 경우 현재 입력 위치로 방향키를 옮겨줌
                _touchPad.position = input;

            }
        }
        //버튼을 누르지 않은 경우
        else
        {
            //버튼에서 손이 뗴어질 경우, 방향키를 원래 위치로 변경함
            _touchPad.position = _starPos;
        }

        //방향키와 기준점의 차이를 계산함
        Vector3 diff = _touchPad.position - _starPos;
        
        //거리만 나누어 방향을 계산함
        Vector2 normDiff = new Vector3(diff.x / _dragRadius, diff.y / _dragRadius);

        if(_player != null)
        {
            //플레이어에게 변경된 좌표를 전달합니다
            _player.onStickChanged(normDiff);
        }
    }


}
