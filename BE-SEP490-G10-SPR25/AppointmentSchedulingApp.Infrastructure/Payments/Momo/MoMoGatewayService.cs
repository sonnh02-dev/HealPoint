using AppointmentSchedulingApp.Application.Abstractions.Payment;
using AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;
using AppointmentSchedulingApp.Domain.Commons;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace AppointmentSchedulingApp.Infrastructure.Payments.Momo
{
    public class MoMoGatewayService : IPaymentGatewayService
    {
        //    private readonly IConfiguration _config;
        //    private readonly IUnitOfWork _unitOfWork;
        //    private readonly IMapper _mapper;
        //    public IReservationService _reservationService;
        //    private readonly IDistributedCache _cache;
        //    private readonly INotificationService _notificationService;
        //    public string PaymentGatewayName => "MoMo";

        //    public MoMoGatewayService(
        //        IConfiguration config,
        //        IUnitOfWork unitOfWork,
        //        IMapper mapper,
        //        IReservationService reservationService,
        //        IDistributedCache cache,
        //        INotificationService notificationService)
        //    {
        //        _config = config;
        //        _unitOfWork = unitOfWork;
        //        _mapper = mapper;
        //        _reservationService = reservationService;
        //        _cache = cache;
        //        _notificationService = notificationService;
        //    }

        //    public async Task<string> CreatePaymentUrl(HttpContext? context, PaymentRequestDTO model)
        //    {
        //        string lockKey = $"hold_schedule_{model.Reservation.DoctorScheduleId}_{model.Reservation.AppointmentDate:yyyyMMddHHmm}";
        //        var existing = await _cache.GetStringAsync(lockKey);

        //        if (existing != null)
        //        {
        //            await _notificationService.NotifyScheduleConflictAsync(
        //                model.Reservation.PatientId.ToString(),
        //                "Lịch hẹn này đã được giữ chỗ. Vui lòng chọn thời gian khác.");
        //            throw new InvalidOperationException("Lịch hẹn đã được người khác chọn. Vui lòng thử lại với thời gian khác.");
        //        }

        //        await _cache.SetStringAsync(lockKey, "locked", new DistributedCacheEntryOptions
        //        {
        //            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        //        });

        //        var partnerCode = _config["MoMo:PartnerCode"];
        //        var accessKey = _config["MoMo:AccessKey"];
        //        var secretKey = _config["MoMo:SecretKey"];
        //        var requestId = Guid.NewGuid().ToString();
        //        var orderId = DateTime.Now.Ticks.ToString();
        //        var orderInfo = Uri.EscapeDataString($"{model.PayerId}|{model.Reservation.PatientId}|{model.Reservation.DoctorScheduleId}|{model.Reservation.Reason}|{model.Reservation.AppointmentDate:yyyyMMddHHmmss}|{model.Reservation.CreatedByUserId}|{model.Reservation.UpdatedByUserId}");

        //        var rawHash = $"accessKey={accessKey}&amount={model.Amount}&extraData=&ipnUrl={_config["MoMo:NotifyUrl"]}&orderId={orderId}&orderInfo={orderInfo}&partnerCode={partnerCode}&redirectUrl={_config["MoMo:ReturnUrl"]}&requestId={requestId}&requestType=captureWallet";

        //        string signature;
        //        using (var hmac = new System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
        //        {
        //            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(rawHash));
        //            signature = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        //        }

        //        var payload = new
        //        {
        //            partnerCode,
        //            accessKey,
        //            requestId,
        //            amount = model.Amount.ToString(),
        //            orderId,
        //            orderInfo,
        //            redirectUrl = _config["MoMo:ReturnUrl"],
        //            ipnUrl = _config["MoMo:NotifyUrl"],
        //            requestType = "captureWallet",
        //            extraData = "",
        //            signature,
        //            lang = "vi"
        //        };

        //        using var httpClient = new HttpClient();
        //        var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
        //        var response = await httpClient.PostAsync(_config["MoMo:Endpoint"], content);
        //        var responseBody = await response.Content.ReadAsStringAsync();

        //        dynamic result = JsonConvert.DeserializeObject(responseBody);
        //        return result.payUrl;
        //    }

        //    public async Task<PaymentResponseDTO> HandlePaymentCallbackAsync(IQueryCollection collections)
        //    {
        //        var resultCode = collections["resultCode"];
        //        var orderInfoRaw = Uri.UnescapeDataString(collections["orderInfo"]);
        //        var parts = orderInfoRaw.Split('|');

        //        if (parts.Length < 7)
        //        {
        //            return new PaymentResponseDTO { PaymentStatus = "Thông tin đơn hàng không hợp lệ" };
        //        }

        //        int payerId = int.Parse(parts[0]);
        //        int patientId = int.Parse(parts[1]);
        //        int doctorScheduleId = int.Parse(parts[2]);
        //        string reason = parts[3];
        //        DateTime appointmentDate = DateTime.ParseExact(parts[4], "yyyyMMddHHmmss", null);
        //        int createdByUserId = int.Parse(parts[5]);
        //        int updatedByUserId = int.Parse(parts[6]);

        //        string lockKey = $"hold_schedule_{doctorScheduleId}_{appointmentDate:yyyyMMddHHmm}";

        //        if (resultCode != "0")
        //        {
        //            await _cache.RemoveAsync(lockKey);
        //            return new PaymentResponseDTO
        //            {
        //                PaymentStatus = "Thanh toán thất bại",
        //                PaymentMethod = "MoMo"
        //            };
        //        }

        //        try
        //        {
        //            await _unitOfWork.BeginTransactionAsync();

        //            var reservationDto = new AddedReservationDTO
        //            {
        //                PatientId = patientId,
        //                DoctorScheduleId = doctorScheduleId,
        //                Reason = reason,
        //                AppointmentDate = appointmentDate,
        //                CreatedByUserId = createdByUserId,
        //                UpdatedByUserId = updatedByUserId
        //            };

        //            var reservation = _mapper.Map<Appointment>(reservationDto);
        //            await _unitOfWork.AppointmentRepository.AddAsync(reservation);
        //            await _unitOfWork.CommitAsync();
        //            await _reservationService.UpdatePriorExaminationImg(reservation.ReservationId, $"lichhen_{reservation.ReservationId}.jpg");

        //            var payment = new Payment
        //            {
        //                PayerId = payerId,
        //                ReservationId = reservation.ReservationId,
        //                TransactionId = collections["transId"],
        //                Amount = decimal.Parse(collections["amount"]),
        //                PaymentMethod = "MoMo",
        //                PaymentStatus = "Đã thanh toán"
        //            };

        //            await _unitOfWork.PaymentRepository.AddAsync(payment);
        //            await _unitOfWork.CommitTransactionAsync();

        //            return new PaymentResponseDTO
        //            {
        //                ReservationId = reservation.ReservationId,
        //                Amount = payment.Amount,
        //                PaymentStatus = "Giao dịch thành công",
        //                TransactionId = payment.TransactionId,
        //                PaymentMethod = "MoMo"
        //            };
        //        }
        //        catch
        //        {
        //            await _unitOfWork.RollbackTransactionAsync();
        //            throw;
        //        }
        //        finally
        //        {
        //            await _cache.RemoveAsync(lockKey);
        //        }
        //    }
    }

}
