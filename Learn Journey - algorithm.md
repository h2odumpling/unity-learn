# 冒泡
复杂度 O(n^2)
void function Pop (int[] _arr){
  int i,j,temp;
  for(i = 0; i < _arr.Length - 1; i++){
    for(j = i+1; j < _arr.Length; j++){
      if(_arr[i] > _arr[j]){
        temp = _arr[i];
        _arr[i] = _arr[j];
        _arr[j] = temp;
      }
    }
  }
}



# 选择排序
O(n^2)，当n比较小，快于冒泡
void function Selection (int[] _arr){
  int i,j,min,temp;
  for(i = 0; i < _arr.Length - 1; i++){
    min = i;
    for(j = i+1; j < _arr.Length; j++){
      if(_arr[min] > _arr[j]){
        min = j;
      }
    }
    temp = _arr[min];
    _arr[min] = _arr[i];
    _arr[i] = temp;
  }
}



# 插入排序
O(1)，当n比较小时比较适用
void function Insert (int[] _arr){
  int i,j,temp;
  for(i = 1; i < _arr.Length; i++;){
    temp = _arr[i];
    for(j = i-1; j >= 0; j--){
      if(temp > _arr[j]){
        _arr[j+1] = _arr[j];
        _arr[j] = _arr[temp];
      }
    }
  }
}



# 二分查找
必须在有序队列中进行
int function Quick(int[] _arr, int tar){
  int left = 0;
  int right = _arr.Length;
  int mid = 0;
  while(left <= right){
    mid = (left + right) /2;
    if(_arr[mid] == tar){
      return mid;
    }else if(_arr[mid] > tar){
      right = mid - 1;
    }else{
      left = mid + 1;
    }
  }
  return -1;
}







